using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using aaaaaaa.Controladores;
using aaaaaaa.Entidades;
using aaaaaaa.Persistencia;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace aaaaaaa.ui
{
    public partial class Frm_selecionarCliente : Form
    {
        private List<Cliente> Lista = new List<Cliente>();
        private TextBox clienteSelecionado;
        private TextBox idClienteSelecionado;
        public Frm_selecionarCliente(TextBox txt, TextBox id)
        {
            InitializeComponent();
            LerDoBanco();
            atualizarGrid();
            clienteSelecionado = txt;
            idClienteSelecionado = id;
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

        private void button1_Click(object sender, EventArgs e)
        {
            String idCliente = (string)dgvCliente.SelectedRows[0].Cells[0].Value;
            String nomeCliente = (string)dgvCliente.SelectedRows[0].Cells[1].Value;
            clienteSelecionado.Text = nomeCliente;
            idClienteSelecionado.Text = idCliente;
            Close();
        }
    }
}
