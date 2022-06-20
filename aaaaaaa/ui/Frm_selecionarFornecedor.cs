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
    public partial class Frm_selecionarFornecedor : Form
    {
        private List<Fornecedor> Lista = new List<Fornecedor>();
        private TextBox fornecedorSelecionado;
        private TextBox idFornecedorSelecionado;
        public Frm_selecionarFornecedor(TextBox txt, TextBox id)
        {
            InitializeComponent();
            LerDoBanco();
            atualizarGrid();
            fornecedorSelecionado = txt;
            idFornecedorSelecionado = id;
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

        private void button1_Click(object sender, EventArgs e)
        {
            String idFornecedor = (string)dgvFornecedor.SelectedRows[0].Cells[0].Value;
            String nomeFornecedor = (string)dgvFornecedor.SelectedRows[0].Cells[1].Value;
            fornecedorSelecionado.Text = nomeFornecedor;
            idFornecedorSelecionado.Text = idFornecedor;
            Close();
        }
    }
}
