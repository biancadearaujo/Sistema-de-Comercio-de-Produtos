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
    public partial class Frm_consultarVenda : Form
    {
        String filterTipo = "";
        private List<Venda> Lista = new List<Venda>();
        public Frm_consultarVenda()
        {
            InitializeComponent();
            LerDoBanco();
            atualizarGrid();
        }

        //atualizar tabela
        private void atualizarGrid()
        {
            dgvConsultarVenda.Rows.Clear();
            // ve se tem como trazer o nome e nao o id com cliente
            foreach (Venda venda in Lista)
            {
                String[] linha = {
                    venda.idVenda.ToString(), venda.data,  venda.idCliente.ToString(),
                    venda.totalVenda.ToString(), venda.situacaoVenda
                };
                dgvConsultarVenda.Rows.Add(linha);
            }
        }

        //ler do banco
        public void LerDoBanco(String SQL = "SELECT * FROM venda")
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
                    Venda entidade = new Venda();
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

        //filtro por cliente e periodo
        private bool Filtro()
        {
            if (rbCliente.Checked)
            {
                filterTipo = "cliente";
                return true;
            }
            else if (rbPeriodo.Checked)
            {
                filterTipo = "periodo";
                return true;
            }
            else if (rbId.Checked)
            {
                filterTipo = "id";
                return true;
            }
            return false;
        }

        // metodo para pesquisar venda por id cliente e periodo
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (Filtro())
            {
                string pesquisar = txtPesquisar.Text;
                dgvConsultarVenda.Rows.Clear();
                // BancoDados.obterInstancia().conectar();
                foreach (Venda venda in Lista)
                {
                    if (filterTipo == "cliente")
                    {

                        if (venda.idCliente.ToString().Contains(pesquisar))
                        {
                            String[] linha = {
                            venda.idVenda.ToString(), venda.data,  venda.idCliente.ToString(),
                            venda.totalVenda.ToString(), venda.situacaoVenda
                };
                            dgvConsultarVenda.Rows.Add(linha);
                        }
                    }
                    if (filterTipo == "periodo")
                    {
                        if (venda.data.Contains(pesquisar))
                        {
                            String[] linha = {
                            venda.idVenda.ToString(), venda.data,  venda.idCliente.ToString(),
                            venda.totalVenda.ToString(), venda.situacaoVenda
                };
                            dgvConsultarVenda.Rows.Add(linha);
                        }
                    }

                    if (filterTipo == "id")
                    {
                        if (venda.idVenda.ToString().Contains(pesquisar))
                        {
                            String[] linha = {
                            venda.idVenda.ToString(), venda.data,  venda.idCliente.ToString(),
                            venda.totalVenda.ToString(), venda.situacaoVenda
                };
                            dgvConsultarVenda.Rows.Add(linha);
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
