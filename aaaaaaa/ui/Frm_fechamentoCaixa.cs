using aaaaaaa.Entidades;
using aaaaaaa.Controladores;
using aaaaaaa.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace aaaaaaa.ui
{
    public partial class Frm_fechamentoCaixa : Form
    {
        String filterTipo = "";
        private List<MovimentacaoCaixa> Lista = new List<MovimentacaoCaixa>();
        public Frm_fechamentoCaixa()
        {
            InitializeComponent();
            LerDoBanco();
            popularGrid();
            popularGridd();
        }

        private void popularGrid()
        {
            ControladorCadastroContasPagar compras = new ControladorCadastroContasPagar();
            List<Compra> list = new List<Compra>();
            list = compras.buscarComprasBaixa();

            dgvFechamentoCaixa.Rows.Clear();

            foreach (Compra compra in list)
            {
                String[] linha = {
                    compra.idCompra.ToString(), compra.data.ToString(), compra.hora, compra.idFornecedor.ToString(),
                    compra.totalCompra.ToString(), compra.situacaoCompra
                };
                dgvFechamentoCaixa.Rows.Add(linha);
            }
        }

        private void popularGridd()
        {
            ControladorCadastroContasReceber vendas = new ControladorCadastroContasReceber();
            List<Venda> list = new List<Venda>();
            list = vendas.buscarVendasBaixa();

            dgvFechamentoCaixa.Rows.Clear();
            foreach (Venda venda in list)
            {
                String[] linha = {
                    venda.idVenda.ToString(), venda.data.ToString(), venda.hora, venda.idCliente.ToString(),
                    venda.totalVenda.ToString(), venda.situacaoVenda
                };
                dgvFechamentoCaixa.Rows.Add(linha);
            }
        }

        private void atualizarGrid()
        {
            dgvFechamentoCaixa.Rows.Clear();

            foreach (MovimentacaoCaixa movimentacaoCaixa in Lista)
            {
                String[] linha = {
                    movimentacaoCaixa.idCaixa.ToString(), movimentacaoCaixa.dataMovimento,
                    movimentacaoCaixa.valor.ToString()
                };
                dgvFechamentoCaixa.Rows.Add(linha);
            }
        }

        public void LerDoBanco(String SQL = "SELECT * FROM movimentoCaixa")
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
                    MovimentacaoCaixa entidade = new MovimentacaoCaixa();
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

        private bool Filtro()
        {
            if (rbPeriodo.Checked)
            {
                filterTipo = "periodo";
                return true;
            }
            else if (rbDescricao.Checked)
            {
                filterTipo = "descricao";
                return true;
            }
            else if (rbId.Checked)
            {
                filterTipo = "id";
                return true;
            }
            return false;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (Filtro())
            {
                string pesquisar = txtPesquisar.Text;
                dgvFechamentoCaixa.Rows.Clear();
                // BancoDados.obterInstancia().conectar();
                foreach (MovimentacaoCaixa movimentacaoCaixa in Lista)
                {
                    if (filterTipo == "periodo")
                    {

                        if (movimentacaoCaixa.dataMovimento.Contains(pesquisar))
                        {
                            String[] linha = {
                            movimentacaoCaixa.idCaixa.ToString(), movimentacaoCaixa.dataMovimento,
                            movimentacaoCaixa.valor.ToString()
                };
                            dgvFechamentoCaixa.Rows.Add(linha);
                        }
                    }
                    if (filterTipo == "descricao")
                    {
                        if (movimentacaoCaixa.descricao.Contains(pesquisar))
                        {
                            String[] linha = {
                            movimentacaoCaixa.idCaixa.ToString(), movimentacaoCaixa.dataMovimento,
                            movimentacaoCaixa.valor.ToString()
                };
                            dgvFechamentoCaixa.Rows.Add(linha);
                        }
                    }

                    if (filterTipo == "id")
                    {
                        if (movimentacaoCaixa.idCaixa.ToString().Contains(pesquisar))
                        {
                            String[] linha = {
                            movimentacaoCaixa.idCaixa.ToString(), movimentacaoCaixa.dataMovimento,
                            movimentacaoCaixa.valor.ToString()
                };
                            dgvFechamentoCaixa.Rows.Add(linha);
                        }
                    }
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
