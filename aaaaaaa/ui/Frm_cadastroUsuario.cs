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
    public partial class Frm_cadastrarUsuario : Form
    {
        String filterTipo = "";
        private List<Usuario> Lista = new List<Usuario>();
        public Frm_cadastrarUsuario()
        {
            InitializeComponent();
            LerDoBanco();
            atualizarGrid();
        }

        private void atualizarGrid()
        {
            dgvUsuario.Rows.Clear();

            foreach (Usuario usuario in Lista)
            {
                String[] linha = {
                    usuario.idUsuario.ToString(), usuario.nome
                };
                dgvUsuario.Rows.Add(linha);
            }
        }

        public void LerDoBanco(String SQL = "SELECT * FROM usuario")
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
                    Usuario entidade = new Usuario();
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
            Usuario usuario = new Usuario();
            usuario.idUsuario = ControladorCadastroUsuario.BuscarMaiorID() + 1;
            usuario.nome = txtNome.Text;
            usuario.senha = txtSenha.Text;

            if (txtNome.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Preenchimento incompleto!");
            }
            else
            {
                BancoDados.obterInstancia().conectar();
                ControladorCadastroUsuario controladorCadastroUsuario = new ControladorCadastroUsuario();
                controladorCadastroUsuario.incluir(usuario);
                BancoDados.obterInstancia().desconectar();
                LerDoBanco();
                atualizarGrid();
                limpar();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.idUsuario = ControladorCadastroUsuario.BuscarMaiorID() + 1;
            usuario.nome = txtNome.Text;
            usuario.senha = txtSenha.Text;

            if (txtNome.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Preenchimento incompleto!");
            }
            else
            {
                /*BancoDados.obterInstancia().conectar();
                ControladorCadastroUsuario controladorCadastroUsuario = new ControladorCadastroUsuario();
                controladorCadastroUsuario.incluir(usuario);
                BancoDados.obterInstancia().desconectar();*/

                /*BancoDados.obterInstancia().conectar();
                BancoDados.obterInstancia().iniciarTransacao();
                String comando = "update set usuario (nome,senha) VALUES ('" + usuario.nome + "','" + usuario.senha + "','0') where (id_usuario = '" + usuario.idUsuario + "')";
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
            if (dgvUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado!", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Usuario usuario = new Usuario();
                if (dgvUsuario.SelectedRows[0].Cells[0].Value != null)
                {
                    usuario.idUsuario = int.Parse(dgvUsuario.SelectedRows[0].Cells[0].Value.ToString());
                    BancoDados.obterInstancia().conectar();
                    ControladorCadastroUsuario controlador = new ControladorCadastroUsuario();
                    controlador.excluir(usuario);
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
            txtSenha.Text = "";
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (Filtro())
            {
                string pesquisar = txtPesquisar.Text;
                dgvUsuario.Rows.Clear();
                // BancoDados.obterInstancia().conectar();
                foreach (Usuario usuario in Lista)
                {
                    if (filterTipo == "nome")
                    {

                        if (usuario.nome.Contains(pesquisar))
                        {
                            String[] linha = {
                            usuario.idUsuario.ToString(), usuario.nome
                };
                            dgvUsuario.Rows.Add(linha);
                        }
                    }

                    if (filterTipo == "id")
                    {
                        if (usuario.idUsuario.ToString().Contains(pesquisar))
                        {
                            String[] linha = {
                            usuario.idUsuario.ToString(), usuario.nome
                };
                            dgvUsuario.Rows.Add(linha);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado!", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                String nomeUsuario = (string)dgvUsuario.SelectedRows[0].Cells[0].Value;
                String senhaUsuario = (string)dgvUsuario.SelectedRows[0].Cells[1].Value;
                txtNome.Text = nomeUsuario;
                txtSenha.Text = senhaUsuario;
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpar();
        }
    }
}
