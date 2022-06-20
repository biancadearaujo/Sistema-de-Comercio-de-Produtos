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
    public partial class Frm_consultarCompra : Form
    {
        String filterTipo = "";
        private List<Compra> Lista = new List<Compra>();
        public Frm_consultarCompra()
        {
            InitializeComponent();
            LerDoBanco();
            atualizarGrid();
        }

        //atualizar tabela
        private void atualizarGrid()
        {
            dgvConsultarCompra.Rows.Clear();
            // ve se tem como trazer o nome e nao o id com fornecedor
            foreach (Compra compra in Lista)
            {
                String[] linha = {
                    compra.idCompra.ToString(), compra.data,  compra.idFornecedor.ToString(),
                    compra.totalCompra.ToString(), compra.situacaoCompra
                };
                dgvConsultarCompra.Rows.Add(linha);
            }
        }

        //ler do banco
        public void LerDoBanco(String SQL = "SELECT * FROM compra")
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
                    Compra entidade = new Compra();
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

        //filtrar por id cliente e por periodo
        private bool Filtro()
        {
            if (rbFornecedor.Checked)
            {
                filterTipo = "fornecedor";
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

        //ve se pesquisar por id de fornecedor ira funcionar
        // metodo para pesquisar compra por id fornecedor e periodo
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (Filtro())
            {
                string pesquisar = txtPesquisar.Text;
                dgvConsultarCompra.Rows.Clear();
                // BancoDados.obterInstancia().conectar();
                foreach (Compra compra in Lista)
                {
                    if (filterTipo == "fornecedor")
                    {

                        if (compra.idFornecedor.ToString().Contains(pesquisar))
                        {
                            String[] linha = {
                            compra.idCompra.ToString(), compra.data,  compra.idFornecedor.ToString(),
                            compra.totalCompra.ToString(), compra.situacaoCompra
                };
                            dgvConsultarCompra.Rows.Add(linha);
                        }
                    }
                    if (filterTipo == "periodo")
                    {
                        if (compra.data.Contains(pesquisar))
                        {
                            String[] linha = {
                            compra.idCompra.ToString(), compra.data,  compra.idFornecedor.ToString(),
                            compra.totalCompra.ToString(), compra.situacaoCompra
                };
                            dgvConsultarCompra.Rows.Add(linha);
                        }
                    }

                    if (filterTipo == "id")
                    {
                        if (compra.idCompra.ToString().Contains(pesquisar))
                        {
                            String[] linha = {
                            compra.idCompra.ToString(), compra.data,  compra.idFornecedor.ToString(),
                            compra.totalCompra.ToString(), compra.situacaoCompra
                };
                            dgvConsultarCompra.Rows.Add(linha);
                        }
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
