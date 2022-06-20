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
    public partial class Frm_selecionarProduto : Form
    {
        private List<Produto> Lista = new List<Produto>();
        public Produto produtoSelecionado = new Produto();

        public Frm_selecionarProduto()
        {
            InitializeComponent();
            LerDoBanco();
            atualizarGrid();
        }

        public void LerDoBanco(String SQL = "SELECT * FROM produto")
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
                    Produto entidade = new Produto();
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
            dgvProduto.Rows.Clear();
            foreach (Produto produto in Lista)
            {
                String[] linha = {
                    produto.idProduto.ToString(), produto.nome, produto.quantidadeEstoque.ToString(),
                    produto.preco.ToString(), produto.unidade, produto.idFornecedor.ToString()
                };
                dgvProduto.Rows.Add(linha);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String idProduto = (string)dgvProduto.SelectedRows[0].Cells[0].Value;
            

            foreach (Produto produto in Lista)
            {
                if (idProduto.Equals(produto.idProduto.ToString()))
                {
                    produtoSelecionado = produto;
                }
            }

            Close();
        }

    }
}
