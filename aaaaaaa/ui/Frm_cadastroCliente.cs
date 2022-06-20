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
    public partial class Frm_cadastroCliente : Form
    {
        String filterTipo = "";
        private List<Cliente> Lista = new List<Cliente>();
        public Frm_cadastroCliente()
        {
            InitializeComponent();
            LerDoBanco();
            atualizarGrid();
        }

        private void atualizarGrid()
        {
            dgvCliente.Rows.Clear();

            foreach (Cliente cliente in Lista)
            {
                String[] linha = {
                    cliente.idCliente.ToString(), cliente.nome,
                    cliente.telefone.ToString(), cliente.email,  cliente.rua, cliente.numero,
                    cliente.complemento, cliente.bairro, cliente.cidade, cliente.uf, cliente.cep
                };
                dgvCliente.Rows.Add(linha);
            }
        }

        public void LerDoBanco(String SQL = "SELECT * FROM cliente")
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
                    Cliente entidade = new Cliente();
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
            Cliente cliente = new Cliente();
            cliente.idCliente = ControladorCadastroCliente.BuscarMaiorID() + 1;
            cliente.nome = txtNome.Text;
            cliente.telefone = txtTelefone.Text;
            cliente.email = txtEmail.Text;
            cliente.rua = txtRua.Text;
            cliente.numero = txtNumero.Text;
            cliente.complemento = txtComplemento.Text;
            cliente.bairro = txtBairro.Text;
            cliente.cidade = txtCidade.Text;
            cliente.uf = cbUf.Text;
            cliente.cep = txtCep.Text;

            BancoDados.obterInstancia().conectar();
            ControladorCadastroCliente controladorCadastroCliente = new ControladorCadastroCliente();
            controladorCadastroCliente.incluir(cliente);
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
            Cliente cliente = new Cliente();
            if (dgvCliente.SelectedRows[0].Cells[0].Value != null)
            {
                cliente.idCliente = int.Parse(dgvCliente.SelectedRows[0].Cells[0].Value.ToString());
                BancoDados.obterInstancia().conectar();
                ControladorCadastroCliente controlador = new ControladorCadastroCliente();
                controlador.excluir(cliente);
                BancoDados.obterInstancia().desconectar();
                LerDoBanco();
                atualizarGrid();
            }
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
            /*MySqlDataAdapter dataAdapter = new MySqlDataAdapter(criarComando("SELECT * FROM produto WHERE nome LIKE \"%" + txtPesquisar.Text + "%\""));
            criarTabela(dataAdapter);*/
            if (Filtro())
            {
                string pesquisar = txtPesquisar.Text;
                dgvCliente.Rows.Clear();
               // BancoDados.obterInstancia().conectar();
                foreach (Cliente cliente in Lista)
                {
                    if (filterTipo == "nome")
                    {
                        if (cliente.nome.Contains(pesquisar))
                        {
                            String[] linha = {
                            cliente.idCliente.ToString(), cliente.nome,
                            cliente.telefone.ToString(), cliente.email,  cliente.rua, cliente.numero,
                            cliente.complemento, cliente.bairro, cliente.cidade, cliente.uf, cliente.cep
                            };
                            dgvCliente.Rows.Add(linha);
                        }
                    }
                    if (filterTipo == "telefone")
                    {
                        if (cliente.telefone.Contains(pesquisar))
                        {
                            String[] linha = {
                            cliente.idCliente.ToString(), cliente.nome,
                            cliente.telefone.ToString(), cliente.email,  cliente.rua, cliente.numero,
                            cliente.complemento, cliente.bairro, cliente.cidade, cliente.uf, cliente.cep
                            };
                            dgvCliente.Rows.Add(linha);
                        }
                    }
                    if (filterTipo == "email")
                    {
                        if (cliente.email.Contains(pesquisar))
                        {
                            String[] linha = {
                            cliente.idCliente.ToString(), cliente.nome,
                            cliente.telefone.ToString(), cliente.email,  cliente.rua, cliente.numero,
                            cliente.complemento, cliente.bairro, cliente.cidade, cliente.uf, cliente.cep
                            };
                            dgvCliente.Rows.Add(linha);
                        }
                    }

                    if (filterTipo == "id")
                    {
                        if (cliente.idCliente.ToString().Contains(pesquisar))
                        {
                            String[] linha = {
                            cliente.idCliente.ToString(), cliente.nome,
                            cliente.telefone.ToString(), cliente.email,  cliente.rua, cliente.numero,
                            cliente.complemento, cliente.bairro, cliente.cidade, cliente.uf, cliente.cep
                            };
                            dgvCliente.Rows.Add(linha);
                        }
                    }
                }
            }
        }
    }
}
