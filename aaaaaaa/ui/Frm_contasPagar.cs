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
    public partial class Frm_contasPagar : Form
    {
        public Frm_contasPagar()
        {
            InitializeComponent();
            popularGrid();
        }

        private void popularGrid()
        {
            ControladorCadastroContasPagar compras = new ControladorCadastroContasPagar();
            List<Compra> list = new List<Compra>();
            list = compras.buscarComprasBaixa();

            dataGridView1.Rows.Clear();

            foreach (Compra compra in list)
            {
                String[] linha = {
                    compra.idCompra.ToString(), compra.data.ToString(), compra.hora, compra.idFornecedor.ToString(),
                    compra.totalCompra.ToString(), compra.situacaoCompra
                };
                dataGridView1.Rows.Add(linha);
            }
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

            ControladorCadastroContasPagar compra = new ControladorCadastroContasPagar();
            List<ContasPagar> Lista = compra.buscarComprasRelatorio(filterTipo);

            //instalar a biblioteca
           /* StreamWriter sw = new StreamWriter("./Relatorios/relatorio.txt");

            foreach (ContasPagar ven in Lista)
            {
                sw.WriteLine("Id_venda: " + ven.idContaPagar);
                sw.WriteLine("Id_cliente: " + ven.idFornecedor);
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
            String idCompra = dataGridView1.Rows[linhaAtual].Cells[0].Value.ToString();
            ControladorCadastroContasPagar compra = new ControladorCadastroContasPagar();
            BancoDados.obterInstancia().conectar();
            compra.darBaixaCompra(idCompra);
            MessageBox.Show("Baixa realizada com sucesso!");
            popularGrid();
        }
    }
}
