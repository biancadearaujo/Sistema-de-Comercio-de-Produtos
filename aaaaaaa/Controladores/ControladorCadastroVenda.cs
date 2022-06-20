using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using aaaaaaa.Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace aaaaaaa.Controladores
{
    class ControladorCadastroVenda 
    {
        private ControladorCadastroItemVenda controladorItemVenda;

        public void selecionar(Venda venda)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                MySqlCommand comandoSelecao = new MySqlCommand("SELECT * FROM venda WHERE id_venda = " +
                     venda.idVenda, BancoDados.obterInstancia().obterConexao());
                MySqlDataReader leitorDados = comandoSelecao.ExecuteReader();
                while (leitorDados.Read())
                {
                    venda.lerDados(leitorDados);
                }
                leitorDados.Close();
                BancoDados.obterInstancia().confirmarTransacao();
            }
            catch (Exception ex)
            {
                BancoDados.obterInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }

        public void incluir(Venda venda)
         {
             BancoDados.obterInstancia().iniciarTransacao();
             controladorItemVenda = new ControladorCadastroItemVenda();
             try
             {
                 MySqlCommand comandoInclusao = new MySqlCommand("INSERT INTO venda VALUES ('" + venda.idVenda + "','" + venda.data + "','" + venda.hora + "','" + venda.idCliente + "','" + venda.totalVenda + "','" + venda.situacaoVenda + "','" + venda.formaPagamento + "')", BancoDados.obterInstancia().obterConexao());
                 comandoInclusao.ExecuteNonQuery();
                 foreach (ItemVenda item in venda.itens)
                 {
                     try
                     {
                         controladorItemVenda.incluir(item);
                     }
                     catch (Exception ex)
                     {
                         throw new Exception(ex.Message);
                        // MessageBox.Show("Message");
                     }
                 }
                 BancoDados.obterInstancia().confirmarTransacao();
             }
             catch (Exception ex)
             {
                 BancoDados.obterInstancia().cancelarTransacao();
                // MessageBox.Show();
                 throw new Exception(ex.Message);
                 //MessageBox.Show("Message");
             }
         }
        
        public static int BuscarMaiorID()
        {
            Venda entidade = new Venda();
            String SQL = "SELECT * FROM venda ORDER BY id_venda DESC LIMIT 0, 1";

            BancoDados.obterInstancia().conectar();
            MySqlCommand comandoSelecao = new MySqlCommand(SQL, BancoDados.obterInstancia().obterConexao());
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                MySqlDataReader leitorDados = comandoSelecao.ExecuteReader();
                if (leitorDados.Read())
                {
                    entidade.lerDados(leitorDados);
                }
                else
                {
                    entidade.idVenda = 0;
                }
                leitorDados.Close();
                BancoDados.obterInstancia().confirmarTransacao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            BancoDados.obterInstancia().desconectar();

            return entidade.idVenda;
        }

        public static List<Venda> BuscarMultiplos(String coluna, String nome)
        {
            List<Venda> Lista = new List<Venda>();
            String SQL = "SELECT * FROM venda WHERE " + coluna + " LIKE \"%" + nome + "%\"";

            BancoDados.obterInstancia().conectar();
            MySqlCommand comandoSelecao = new MySqlCommand(SQL, BancoDados.obterInstancia().obterConexao());
            BancoDados.obterInstancia().iniciarTransacao();
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

            return Lista;
        }
    }
}
