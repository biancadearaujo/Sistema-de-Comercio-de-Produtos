using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Persistencia
{
    class BancoDados
    {
        //atributos 
        private int porta = 3306;
        private string servidor = "localhost";
        private string nomeBancoDados = "vendas";
        private MySqlConnection conexao;
        private static BancoDados instancia = null; //para o singleton
        private MySqlTransaction transacao;
        private string senha = "";

        private bool iniciado = false;

        //preparar string de conexao
        private string criarStringConexao(string usuario, string senha)
        {
            return "server = " + servidor +
                   ";port = " + porta.ToString() +
                   ";database = " + nomeBancoDados +
                   ";user id = " + usuario +
                   ";password = " + senha;
        }

        //metodo de fazer conexao
        public void conectar(string usuario, string senha)
        {
            try
            {
                conexao = new MySqlConnection(criarStringConexao(usuario, senha));
                conexao.Open();
                //MessageBox.Show("Conexão realizada com sucesso");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw new Exception(ex.Message);
            }
        }

        //fazer conexao usando o usuario e a senha
        public void conectar()
        {
            //usbw é a senha usada no USBWebServer
            conectar("root", "123456");
        }

        //metodo para fechar a conexao
        public void desconectar()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
                conexao.Dispose();

            }
        }
        //metodo para retornar a instancia da conexao
        public MySqlConnection obterConexao()
        {
            return conexao;
        }

        public void iniciarTransacao()
        {
            transacao = (MySqlTransaction)conexao.BeginTransaction();
        }

        public void iniciarTransacaoOtimizado()
        {
            if (!iniciado)
            {
                transacao = (MySqlTransaction)conexao.BeginTransaction();
                iniciado = true;
            }
        }

        public void finalizarTransacao()
        {
            iniciado = false;
        }

        //metodo para confirmar transacao
        public void confirmarTransacao()
        {
            if (transacao != null)
            {
                transacao.Commit();
                transacao.Dispose();
            }
        }

        //metodo para cancelar uma transacao
        public void cancelarTransacao()
        {
            if (transacao != null)
            {
                transacao.Rollback();
                transacao.Dispose();
            }

        }

        //metodo para cria e retornar uma instancia 
        public static BancoDados obterInstancia()
        {
            if (instancia == null)
            {
                instancia = new BancoDados();
            }
            return instancia;
        }
    }
}
