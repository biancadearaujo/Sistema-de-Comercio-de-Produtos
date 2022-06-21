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

            if (txtNome.Text == "" || txtTelefone.Text == "" || txtEmail.Text == "" || txtRua.Text == "" || txtNumero.Text == "" || txtComplemento.Text == "" || txtBairro.Text == "" || txtCidade.Text == "" || cbUf.Text == "" || txtCep.Text == "")
            {
                MessageBox.Show("Preenchimento incompleto!");
            }
            else
            {
                BancoDados.obterInstancia().conectar();
                ControladorCadastroCliente controladorCadastroCliente = new ControladorCadastroCliente();
                controladorCadastroCliente.incluir(cliente);
                BancoDados.obterInstancia().desconectar();
                LerDoBanco();
                atualizarGrid();
                limpar();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
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

            if (txtNome.Text == "" || txtTelefone.Text == "" || txtEmail.Text == "" || txtRua.Text == "" || txtNumero.Text == "" || txtComplemento.Text == "" || txtBairro.Text == "" || txtCidade.Text == "" || cbUf.Text == "" || txtCep.Text == "")
            {
                MessageBox.Show("Preenchimento incompleto!");
            }
            else
            {
                /*BancoDados.obterInstancia().conectar();
                ControladorCadastroCliente controladorCadastroCliente = new ControladorCadastroCliente();
                controladorCadastroCliente.atualizar(cliente);
                BancoDados.obterInstancia().desconectar();*/

                /*BancoDados.obterInstancia().conectar();
                BancoDados.obterInstancia().iniciarTransacao();
                String comando = "update set cliente (nome,telefone,email,rua,numero,complemento,bairro,cidade,uf,cep) VALUES ('" + cliente.nome + "','" + cliente.telefone + "','" + cliente.email + "','" + cliente.rua + "','" + cliente.numero + "','" + cliente.complemento + "','" + cliente.bairro + "','" + cliente.cidade + "','" + cliente.uf + "','" + cliente.cep + "','0') where id_cliente = '" + cliente.idCliente + "'";
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
            if (dgvCliente.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado!", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado!", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                String nomeCliente = (string)dgvCliente.SelectedRows[0].Cells[1].Value;
                String telefoneCliente = (string)dgvCliente.SelectedRows[0].Cells[2].Value;
                String emailCliente = (string)dgvCliente.SelectedRows[0].Cells[3].Value;
                String ruaCliente = (string)dgvCliente.SelectedRows[0].Cells[4].Value;
                String numeroCliente = (string)dgvCliente.SelectedRows[0].Cells[5].Value;
                String complementoCliente = (string)dgvCliente.SelectedRows[0].Cells[6].Value;
                String bairroCliente = (string)dgvCliente.SelectedRows[0].Cells[7].Value;
                String cidadeCliente = (string)dgvCliente.SelectedRows[0].Cells[8].Value;
                String ufCliente = (string)dgvCliente.SelectedRows[0].Cells[9].Value;
                String cepCliente = (string)dgvCliente.SelectedRows[0].Cells[10].Value;

                txtNome.Text = nomeCliente;
                txtTelefone.Text = telefoneCliente;
                txtEmail.Text = emailCliente;
                txtRua.Text = ruaCliente;
                txtNumero.Text = numeroCliente;
                txtComplemento.Text = complementoCliente;
                txtBairro.Text = bairroCliente;
                txtCidade.Text = cidadeCliente;
                cbUf.Text = ufCliente;
                txtCep.Text = cepCliente;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpar();
        }
    }
}
