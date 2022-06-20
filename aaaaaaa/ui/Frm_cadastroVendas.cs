﻿using aaaaaaa.Controladores;
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
    public partial class Frm_cadastroVendas : Form
    {
        private List<Produto> lista = new List<Produto>();
        private int quantidadeProduto;
        private Produto produtoEscolhido;
        private List<ItemVenda> listaProdutos = new List<ItemVenda>();

        public Frm_cadastroVendas()
        {
            InitializeComponent();
        }


        private void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            ui.Frm_selecionarCliente frm = new ui.Frm_selecionarCliente(clienteSelecionado,idClienteSelecionado);
            frm.Show();

        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            ui.Frm_selecionarProduto frm = new ui.Frm_selecionarProduto();
            frm.ShowDialog();
            produtoEscolhido = frm.produtoSelecionado;
            idProdutoSelecionado.Text = produtoEscolhido.idProduto.ToString();
            produtoSelecionado.Text = produtoEscolhido.nome.ToString();
            unidadeSelecionada.Text = produtoEscolhido.unidade.ToString();
            valorSelecionado.Text = produtoEscolhido.preco.ToString();
            this.quantidadeProduto = Int32.Parse(produtoEscolhido.quantidadeEstoque.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Int32.Parse(txtQuantidade.Text) > this.quantidadeProduto)
            {
                MessageBox.Show("Quantidade acima do estoque");
            }
            else if (produtoEscolhido.idProduto.ToString() != "0")
            {

                float valor = float.Parse(produtoEscolhido.preco.ToString()) * Int32.Parse(txtQuantidade.Text);
                MessageBox.Show("" + valor);
                String[] linha = {
                    produtoEscolhido.idProduto.ToString(), produtoEscolhido.nome, produtoEscolhido.quantidadeEstoque.ToString(),
                    valor.ToString(), txtQuantidade.Text, produtoEscolhido.idFornecedor.ToString()
                };

                dgvAdicionarProduto.Rows.Add(linha);
                idProdutoSelecionado.Text = "";
                produtoSelecionado.Text = "";
                unidadeSelecionada.Text = "";
                valorSelecionado.Text = "";

                float valorFinal = valor + float.Parse(txtValorTotal.Text.ToString());
                txtValorTotal.Text = valorFinal.ToString();
                txtSubtotal.Text = valorFinal.ToString();
                produtoEscolhido = new Produto();
            }
            else
            {
                MessageBox.Show("Selecione um produto");
            }
           
        }

        private void txtTotalPago_Leave(object sender, EventArgs e)
        {
            float valorTotal = float.Parse(txtValorTotal.Text.ToString());
            float valorPago = float.Parse(txtTotalPago.Text.ToString());
            if (valorTotal < valorPago)
            {
                txtTroco.Text = (valorPago - valorTotal).ToString();
            }
            else
            {
                txtTroco.Text = "0"; 
            }
        }

        private void btnEfetuarPagamento_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado.Text.ToString().Equals(""))
            {
                MessageBox.Show("Selecione um cliente para finalizar venda");
                return;
            }

            int qtdItens = dgvAdicionarProduto.RowCount - 1;

            if(qtdItens <= 0)
            {
                MessageBox.Show("Selecione um ou mais produtos para finalizar venda");
                return;
            }

            //Adicionando id e preço do produto na lista de produtos 'lista'
            for(int i = 0; i < qtdItens; i++)
            {
                ItemVenda ven = new ItemVenda();
                ven.idProduto = Int32.Parse(dgvAdicionarProduto.Rows[i].Cells[0].Value.ToString());
                ven.valorUnitario = float.Parse(dgvAdicionarProduto.Rows[i].Cells[3].Value.ToString());
                ven.quantidade = Int32.Parse(dgvAdicionarProduto.Rows[i].Cells[4].Value.ToString());
                listaProdutos.Add(ven);
            }

            //Os produtos estão na variavel listaProdutos, com as informações: ID, PREÇO, QUANTIDADE

            float valorTotal = float.Parse(txtValorTotal.Text.ToString());
            float valorTotalPago = float.Parse(txtTotalPago.Text.ToString());
            float troco = float.Parse(txtTroco.Text.ToString());
            string meioPagamento = checarMeioPagamento();

            DateTime thisDay = DateTime.Now;
            string data = thisDay.ToString("yyyy-MM-dd");
            string hora = thisDay.ToString("HH:mm:ss");

            Venda venda = new Venda();
            venda.idVenda = ControladorCadastroVenda.BuscarMaiorID() + 1;
            venda.data = data;
            venda.hora = hora;
            venda.idCliente = Int32.Parse(idClienteSelecionado.Text);
            venda.totalVenda = valorTotal;
            venda.situacaoVenda = "ativa";
            venda.formaPagamento = checarMeioPagamento();
            venda.itens = listaProdutos;

            BancoDados.obterInstancia().conectar();
            BancoDados.obterInstancia().iniciarTransacao();
            String comando = "insert into contareceber (id_conta_receber,id_cliente,data_lancamento,data_vencimento,valor,recebido) VALUES ('" + venda.idVenda+ "','" + venda.idCliente + "','" + venda.data + "','" + venda.data + "','" + venda.totalVenda + "','0')";
            MySqlCommand comandoUpdate = new MySqlCommand(comando, BancoDados.obterInstancia().obterConexao());
            comandoUpdate.ExecuteNonQuery();
            BancoDados.obterInstancia().confirmarTransacao();

            BancoDados.obterInstancia().conectar();
            ControladorCadastroVenda controladorCadastroVenda = new ControladorCadastroVenda();
            controladorCadastroVenda.incluir(venda);
            MessageBox.Show("Compra aprovada");
            BancoDados.obterInstancia().desconectar();
            Close();
        }

        private string checarMeioPagamento()
        {
            string meioPagamento = "";
            if (rbPix.Checked)
            {
                meioPagamento = "pix";
            }
            if (rbDinheiro.Checked)
            {
                meioPagamento = "dinheiro";
            }
            if (rbCartaoDebito.Checked)
            {
                meioPagamento = "cartao_debito";
            }
            if (rbCartaoCredito.Checked)
            {
                meioPagamento = "cartao_credito";
            }
            return meioPagamento;
        }
    }
}
