using aaaaaaa.Controladores;
using aaaaaaa.Entidades;
using aaaaaaa.Persistencia;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace aaaaaaa.ui
{
    public partial class Frm_contasReceber : Form
    {
        private List<Venda> Lista = new List<Venda>();
        private List<Venda> list = new List<Venda>();
        public Frm_contasReceber()
        {
            InitializeComponent();
            LerDoBanco();
            popularGrid();
            atualizarGrid();
        }

        private void popularGrid()
        {
            ControladorCadastroContasReceber vendas = new ControladorCadastroContasReceber();
            List<Venda> list = new List<Venda>();
            list = vendas.buscarVendasBaixa();

            dataGridView1.Rows.Clear();
            foreach (Venda venda in list)
            {
                String[] linha = {
                    venda.idVenda.ToString(), venda.data.ToString(), venda.hora, venda.idCliente.ToString(),
                    venda.totalVenda.ToString(), venda.situacaoVenda
                };
                dataGridView1.Rows.Add(linha);
            }
        }

        private void atualizarGrid()
        {
            dataGridView1.Rows.Clear();
            // ve se tem como trazer o nome e nao o id com cliente
            foreach (Venda venda in Lista)
            {
                String[] linha = {
                    venda.idVenda.ToString(), venda.data,  venda.idCliente.ToString(),
                    venda.totalVenda.ToString(), venda.situacaoVenda
                };
                dataGridView1.Rows.Add(linha);
            }
        }

        public void LerDoBanco(String SQL = "SELECT venda.* FROM venda right join contareceber cr on (cr.id_conta_receber = venda.id_venda) where cr.recebido = 0")
        {
            BancoDados.obterInstancia().conectar();
            MySqlCommand comandoSelecao = new MySqlCommand(SQL, BancoDados.obterInstancia().obterConexao());
            BancoDados.obterInstancia().iniciarTransacao();
            Lista.Clear();
            try
            {
                MySqlDataReader leitorDados = comandoSelecao.ExecuteReader();
                while (leitorDados.Read())
                {
                    Venda entidade = new Venda();
                    entidade.lerDados(leitorDados);
                    Lista.Add(entidade);
                }
                leitorDados.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            BancoDados.obterInstancia().desconectar();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            String filterTipo = "";
            if (rbReceber.Checked)
            {
                filterTipo = "a_receber";
            }
            else if (rbVencer.Checked)
            {
                filterTipo = "a_vencer";
            }
            else if (rbAtraso.Checked)
            {
                filterTipo = "em_atraso";
            }
            else if (rbPagas.Checked)
            {
                filterTipo = "pagas";
            }

            ControladorCadastroContasReceber venda = new ControladorCadastroContasReceber();
            List<ContasReceber> Lista = venda.buscarVendasRelatorio(filterTipo);

            //instalar a biblioteca
           /* StreamWriter sw = new StreamWriter("./Relatorios/relatorio.txt");

            foreach (ContasReceber ven in Lista)
            {
                sw.WriteLine("Id_venda: " + ven.idContaReceber);
                sw.WriteLine("Id_cliente: " + ven.idCliente);
                sw.WriteLine("Valor da venda: " + ven.valor);
                sw.WriteLine("Data da venda: " + ven.dataLancamento);
                sw.WriteLine("Data vencimento da venda: " + ven.dataVencimento);
                sw.WriteLine("-----------------------------------------------------------");
            }
            sw.Close();*/
        }

        private void btnBaixa_Click(object sender, EventArgs e)
        {
            int linhaAtual = dataGridView1.CurrentRow.Index;
            String idVenda = dataGridView1.Rows[linhaAtual].Cells[0].Value.ToString();
            ControladorCadastroContasReceber venda = new ControladorCadastroContasReceber();
            BancoDados.obterInstancia().conectar();
            venda.darBaixaVenda(idVenda);
            MessageBox.Show("Baixa realizada com sucesso!");
            popularGrid();
        }
    }
}
