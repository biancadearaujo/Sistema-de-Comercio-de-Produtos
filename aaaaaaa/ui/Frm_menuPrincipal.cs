using aaaaaaa.Controladores;
using aaaaaaa.Entidades;
using aaaaaaa.Persistencia;
using aaaaaaa.ui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aaaaaaa
{
    public partial class Frm_menuPrincipal : Form
    {
        public Frm_menuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BancoDados.obterInstancia().conectar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Contato contato = new Contato();
            contato.nome = txtnome.Text;
            contato.email = txtEmail.Text;
            contato.telefone = txtTelefone.Text;

            BancoDados.obterInstancia().conectar();
            ControladorCadastroContato controladorCadastroContato = new ControladorCadastroContato();
            controladorCadastroContato.incluir(contato);
            BancoDados.obterInstancia().desconectar();

            this.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadProduto_Click(object sender, EventArgs e)
        {
            ui.Frm_cadastroProduto frm = new ui.Frm_cadastroProduto();
            frm.Show();
        }

        private void btnCadCliente_Click(object sender, EventArgs e)
        {
            ui.Frm_cadastroCliente frm = new ui.Frm_cadastroCliente();
            frm.Show();
        }

        private void btnCadVenda_Click(object sender, EventArgs e)
        {
            ui.Frm_cadastroVendas frm = new ui.Frm_cadastroVendas();
            frm.Show();
        }

        private void btnConsProduto_Click(object sender, EventArgs e)
        {

        }

        private void btnCosnCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnConsVenda_Click(object sender, EventArgs e)
        {

        }

        private void btnCadUsuario_Click(object sender, EventArgs e)
        {
            Frm_cadastrarUsuario frm = new Frm_cadastrarUsuario();
            frm.Show();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            ui.Frm_cadastroFornecedor frm = new ui.Frm_cadastroFornecedor();
            frm.Show();
        }

        private void btnContasReceber_Click(object sender, EventArgs e)
        {
            ui.Frm_contasReceber frm = new ui.Frm_contasReceber();
            frm.Show();
        }

        private void btnContasPagar_Click(object sender, EventArgs e)
        {
            ui.Frm_contasPagar frm = new ui.Frm_contasPagar();
            frm.Show();
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            ui.Frm_cadastroCompra frm = new ui.Frm_cadastroCompra();
            frm.Show();
        }

        private void btnConsultaVenda_Click(object sender, EventArgs e)
        {
            ui.Frm_consultarVenda frm = new ui.Frm_consultarVenda();
            frm.Show();
        }

        private void btnConsultarCompra_Click(object sender, EventArgs e)
        {
            ui.Frm_consultarCompra frm = new ui.Frm_consultarCompra();
            frm.Show();
        }

        private void btnFechamentoCaixa_Click(object sender, EventArgs e)
        {
            ui.Frm_fechamentoCaixa frm = new ui.Frm_fechamentoCaixa();
            frm.Show();
        }
    }
}
