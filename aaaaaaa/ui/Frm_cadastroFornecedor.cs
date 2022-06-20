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
    public partial class Frm_cadastroFornecedor : Form
    {
        String filterTipo = "";
        private List<Fornecedor> Lista = new List<Fornecedor>();
        public Frm_cadastroFornecedor()
        {
            InitializeComponent();
            LerDoBanco();
            atualizarGrid();
        }

       private void atualizarGrid()
        {
            dgvFornecedor.Rows.Clear();

            foreach (Fornecedor fornecedor in Lista)
            {
                String[] linha = {
                    fornecedor.idFornecedor.ToString(), fornecedor.nome,
                    fornecedor.telefone.ToString(), fornecedor.email,  fornecedor.rua, fornecedor.numero,
                    fornecedor.complemento, fornecedor.bairro, fornecedor.cidade, fornecedor.uf, fornecedor.cep
                };
                dgvFornecedor.Rows.Add(linha);
            }
        }

        public void LerDoBanco(String SQL = "SELECT * FROM fornecedor")
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.idFornecedor = ControladorCadastroFornecedor.BuscarMaiorID() + 1;
            fornecedor.nome = txtNome.Text;
            fornecedor.telefone = txtTelefone.Text;
            fornecedor.email = txtEmail.Text;
            fornecedor.rua = txtRua.Text;
            fornecedor.numero = txtNumero.Text;
            fornecedor.complemento = txtComplemento.Text;
            fornecedor.bairro = txtBairro.Text;
            fornecedor.cidade = txtCidade.Text;
            fornecedor.uf = cbUf.Text;
            fornecedor.cep = txtCep.Text;

            BancoDados.obterInstancia().conectar();
            ControladorCadastroFornecedor controladorCadastroFornecedor = new ControladorCadastroFornecedor();
            controladorCadastroFornecedor.incluir(fornecedor);
            BancoDados.obterInstancia().desconectar();

            LerDoBanco();
            atualizarGrid();
            limpar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            /*Fornecedor fornecedor = new Fornecedor();
            if (dgvFornecedor.SelectedRows[0].Cells[0].Value != null)
            {
                fornecedor.idFornecedor = int.Parse(dgvFornecedor.SelectedRows[0].Cells[0].Value.ToString());
                BancoDados.obterInstancia().conectar();
                ControladorCadastroFornecedor controlador = new ControladorCadastroFornecedor();
                controlador.excluir(fornecedor);
                BancoDados.obterInstancia().desconectar();
                LerDoBanco();
                atualizarGrid();
            }*/
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpar()
        {
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbUf.Text = "";
            txtCep.Text = "";
        }

        private bool Filtro()
        {
            if (rbNome.Checked)
            {
                filterTipo = "nome";
                return true;
            }
            else if (rbTelefone.Checked)
            {
                filterTipo = "telefone";
                return true;
            }
            else if (rbEmail.Checked)
            {
                filterTipo = "email";
                return true;
            }
            else if (rbId.Checked)
            {
                filterTipo = "id";
                return true;
            }
            return false;
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (Filtro())
            {
                string pesquisar = txtPesquisar.Text;
                dgvFornecedor.Rows.Clear();
                // BancoDados.obterInstancia().conectar();
                foreach (Fornecedor fornecedor in Lista)
                {
                    if (filterTipo == "nome")
                    {

                        if (fornecedor.nome.Contains(pesquisar))
                        {
                            String[] linha = {
                            fornecedor.idFornecedor.ToString(), fornecedor.nome,
                            fornecedor.telefone.ToString(), fornecedor.email,  fornecedor.rua, fornecedor.numero,
                            fornecedor.complemento, fornecedor.bairro, fornecedor.cidade, fornecedor.uf, fornecedor.cep
                    };
                            dgvFornecedor.Rows.Add(linha);
                        }
                    }
                    if (filterTipo == "telefone")
                    {
                        if (fornecedor.telefone.Contains(pesquisar))
                        {
                            String[] linha = {
                            fornecedor.idFornecedor.ToString(), fornecedor.nome,
                            fornecedor.telefone.ToString(), fornecedor.email,  fornecedor.rua, fornecedor.numero,
                            fornecedor.complemento, fornecedor.bairro, fornecedor.cidade, fornecedor.uf, fornecedor.cep
                    };
                            dgvFornecedor.Rows.Add(linha);
                        }
                    }
                    if (filterTipo == "email")
                    {
                        if (fornecedor.email.Contains(pesquisar))
                        {
                            String[] linha = {
                            fornecedor.idFornecedor.ToString(), fornecedor.nome,
                            fornecedor.telefone.ToString(), fornecedor.email,  fornecedor.rua, fornecedor.numero,
                            fornecedor.complemento, fornecedor.bairro, fornecedor.cidade, fornecedor.uf, fornecedor.cep
                    };
                            dgvFornecedor.Rows.Add(linha);
                        }
                    }

                    if (filterTipo == "id")
                    {
                        if (fornecedor.idFornecedor.ToString().Contains(pesquisar))
                        {
                            String[] linha = {
                            fornecedor.idFornecedor.ToString(), fornecedor.nome,
                            fornecedor.telefone.ToString(), fornecedor.email,  fornecedor.rua, fornecedor.numero,
                            fornecedor.complemento, fornecedor.bairro, fornecedor.cidade, fornecedor.uf, fornecedor.cep
                    };
                            dgvFornecedor.Rows.Add(linha);
                        }
                    }
                }
            }
        }
    }
}
