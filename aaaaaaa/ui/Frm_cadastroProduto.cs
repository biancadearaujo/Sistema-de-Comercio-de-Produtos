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
    public partial class Frm_cadastroProduto : Form
    {
        String filterTipo = "";
        private List<Fornecedor> Lista = new List<Fornecedor>();
        private List<Produto> ListaProduto = new List<Produto>();
        public Frm_cadastroProduto()
        {
            InitializeComponent();
            LerFornecedor();
            preencherComboBox();
            LerDoBanco();
            atualizarGrid();
        }

        private void atualizarGrid()
        {
            dgvProduto.Rows.Clear();

            foreach (Produto produto in ListaProduto)
            {
                String[] linha = {
                    produto.idProduto.ToString(), produto.nome, produto.quantidadeEstoque.ToString(),
                    produto.preco.ToString(), produto.unidade, produto.idFornecedor.ToString()
                };
                dgvProduto.Rows.Add(linha);
            }
        }

        public void LerDoBanco(String SQL = "SELECT * FROM produto")
        {
            BancoDados.obterInstancia().conectar();
            MySqlCommand comandoSelecao = new MySqlCommand(SQL, BancoDados.obterInstancia().obterConexao());
            BancoDados.obterInstancia().iniciarTransacao();
            ListaProduto.Clear();
            try
            {
                MySqlDataReader leitorDados = comandoSelecao.ExecuteReader();
                while (leitorDados.Read())
                {
                    Produto entidade = new Produto();
                    entidade.lerDados(leitorDados);
                    ListaProduto.Add(entidade);
                }
                leitorDados.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            BancoDados.obterInstancia().desconectar();
        }

        public void LerFornecedor(String SQL = "SELECT * FROM fornecedor")
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
                    Fornecedor entidade = new Fornecedor();
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

        public void preencherComboBox()
        {
            foreach (Fornecedor fornecedor in Lista)
            {
                cbFornecedor.Items.Add(fornecedor.nome);
            }
        }

        private void limpar()
        {
            txtNomeProduto.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";
            cbUnidade.Text = "";
            cbFornecedor.Text = "";
        }

        private bool Filtro()
        {
            if (rbNome.Checked)
            {
                filterTipo = "nome";
                return true;
            }
            else if (rbId.Checked)
            {
                filterTipo = "id";
                return true;
            }
            return false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.idProduto = ControladorCadastroProduto.BuscarMaiorID() + 1;
            produto.nome = txtNomeProduto.Text;
            produto.preco = double.Parse(txtPreco.Text);
            produto.quantidadeEstoque = int.Parse(txtQuantidade.Text);
            produto.preco = double.Parse(txtPreco.Text);
            produto.unidade = cbUnidade.Text;
            produto.idFornecedor = Lista[cbFornecedor.SelectedIndex].idFornecedor;
            //produto.unidade = cbUnidade.SelectedItem.ToString();

            if (txtNomeProduto.Text == "" || txtPreco.Text == "" || txtQuantidade.Text == "" || cbUnidade.Text == "" || cbFornecedor.Text == "")
            {
                MessageBox.Show("Preenchimento incompleto!");
            }
            else
            {
                BancoDados.obterInstancia().conectar();
                ControladorCadastroProduto controladorCadastroProduto = new ControladorCadastroProduto();
                controladorCadastroProduto.incluir(produto);
                BancoDados.obterInstancia().desconectar();
                LerDoBanco();
                atualizarGrid();
                limpar();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.idProduto = ControladorCadastroProduto.BuscarMaiorID() + 1;
            produto.nome = txtNomeProduto.Text;
            produto.preco = double.Parse(txtPreco.Text);
            produto.quantidadeEstoque = int.Parse(txtQuantidade.Text);
            produto.preco = double.Parse(txtPreco.Text);
            produto.unidade = cbUnidade.Text;
            produto.idFornecedor = Lista[cbFornecedor.SelectedIndex].idFornecedor;
            //produto.unidade = cbUnidade.SelectedItem.ToString();

            if (txtNomeProduto.Text == "" || txtPreco.Text == "" || txtQuantidade.Text == "" || cbUnidade.Text == "" || cbFornecedor.Text == "")
            {
                MessageBox.Show("Preenchimento incompleto!");
            }
            else
            {
                /*BancoDados.obterInstancia().conectar();
                ControladorCadastroProduto controladorCadastroProduto = new ControladorCadastroProduto();
                controladorCadastroProduto.atualizar(produto);
                BancoDados.obterInstancia().desconectar();*/

                /*BancoDados.obterInstancia().conectar();
                BancoDados.obterInstancia().iniciarTransacao();
                String comando = "update set produto (nome,preco,quantidade_estoque,unidade,id_fornecedor) VALUES ('" + produto.nome + "','" + produto.preco + "','" + produto.quantidadeEstoque + "','" + produto.unidade + "','" + produto.idFornecedor + "','0') where (id_produto = '" + produto.idProduto + "')";
                MySqlCommand comandoUpdate = new MySqlCommand(comando, BancoDados.obterInstancia().obterConexao());
                comandoUpdate.ExecuteNonQuery();
                BancoDados.obterInstancia().confirmarTransacao();*/

                LerDoBanco();
                atualizarGrid();
                limpar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvProduto.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum produto selecionado!", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Produto produto = new Produto();
                if (dgvProduto.SelectedRows[0].Cells[0].Value != null)
                {
                    produto.idProduto = int.Parse(dgvProduto.SelectedRows[0].Cells[0].Value.ToString());
                    BancoDados.obterInstancia().conectar();
                    ControladorCadastroProduto controlador = new ControladorCadastroProduto();
                    controlador.excluir(produto);
                    BancoDados.obterInstancia().desconectar();
                    LerDoBanco();
                    atualizarGrid();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (Filtro())
            {
                string pesquisar = txtPesquisar.Text;
                dgvProduto.Rows.Clear();
                // BancoDados.obterInstancia().conectar();
                foreach (Produto produto in ListaProduto)
                {
                    if (filterTipo == "nome")
                    {

                        if (produto.nome.Contains(pesquisar))
                        {
                            String[] linha = {
                            produto.idProduto.ToString(), produto.nome, produto.quantidadeEstoque.ToString(),
                            produto.preco.ToString(), produto.unidade, produto.idFornecedor.ToString()
                };
                            dgvProduto.Rows.Add(linha);
                        }
                    }

                    if (filterTipo == "id")
                    {
                        if (produto.idProduto.ToString().Contains(pesquisar))
                        {
                            String[] linha = {
                            produto.idProduto.ToString(), produto.nome, produto.quantidadeEstoque.ToString(),
                            produto.preco.ToString(), produto.unidade, produto.idFornecedor.ToString()
                };
                            dgvProduto.Rows.Add(linha);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvProduto.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado!", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                String nomeProduto = (string)dgvProduto.SelectedRows[0].Cells[1].Value;
                String quantidadeEstoqueProduto = (string)dgvProduto.SelectedRows[0].Cells[2].Value;
                String precoProduto = (string)dgvProduto.SelectedRows[0].Cells[3].Value;
                String unidadeProduto = (string)dgvProduto.SelectedRows[0].Cells[4].Value;
                String idFornecedorProduto = (string)dgvProduto.SelectedRows[0].Cells[5].Value;

                txtNomeProduto.Text = nomeProduto;
                txtQuantidade.Text = quantidadeEstoqueProduto;
                txtPreco.Text = precoProduto;
                cbUnidade.Text = unidadeProduto;
                cbFornecedor.Text = idFornecedorProduto;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpar();
        }
    }
}
