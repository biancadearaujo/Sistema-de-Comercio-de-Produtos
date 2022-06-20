using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using aaaaaaa.Entidades;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Controladores
{
    class ControladorCadastroCompra
    {
        private ControladorCadastroItemCompra controladorItemCompra;

        public void selecionar(Compra compra)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                MySqlCommand comandoSelecao = new MySqlCommand("SELECT * FROM compra WHERE id_compra = " +
                     compra.idCompra, BancoDados.obterInstancia().obterConexao());
                MySqlDataReader leitorDados = comandoSelecao.ExecuteReader();
                while (leitorDados.Read())
                {
                    compra.lerDados(leitorDados);
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

        public void incluir(Compra compra)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            controladorItemCompra = new ControladorCadastroItemCompra();
            try
            {
                MySqlCommand comandoInclusao = new MySqlCommand("INSERT INTO compra VALUES ('" + compra.idCompra + "','" + compra.data + "','" + compra.hora + "','" + compra.idFornecedor + "','" + compra.totalCompra + "','" + compra.situacaoCompra + "','" + compra.formaPagamento + "')", BancoDados.obterInstancia().obterConexao());
                comandoInclusao.ExecuteNonQuery();
                foreach (ItemCompra item in compra.itens)
                {
                    try
                    {
                        controladorItemCompra.incluir(item);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                BancoDados.obterInstancia().confirmarTransacao();
            }
            catch (Exception ex)
            {
                BancoDados.obterInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }

        public void atualizar(string situacao, int id)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                MySqlCommand comandoAtualizacao = new MySqlCommand("UPDATE compra SET situacao_compra = \"" + situacao + "\"" +
                    " WHERE id_compra = " + id, BancoDados.obterInstancia().obterConexao());
                comandoAtualizacao.ExecuteNonQuery();

                List<ItemCompra> itens = new List<ItemCompra>();
                ControladorCadastroItemCompra controladorItem = new ControladorCadastroItemCompra();
                itens = controladorItem.selecionarVarios(id);

                foreach (ItemCompra item in itens)
                {
                    controladorItem.excluir(item);
                }

                BancoDados.obterInstancia().confirmarTransacao();
            }
            catch (Exception ex)
            {
                BancoDados.obterInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }


        public static int BuscarMaiorID()
        {
            Compra entidade = new Compra();
            String SQL = "SELECT * FROM compra ORDER BY id_compra DESC LIMIT 0, 1";

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
                    entidade.idCompra = 0;
                }
                leitorDados.Close();
                BancoDados.obterInstancia().confirmarTransacao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            BancoDados.obterInstancia().desconectar();

            return entidade.idCompra;
        }

        public static List<Compra> BuscarMultiplos(String coluna, String nome)
        {
            List<Compra> Lista = new List<Compra>();
            String SQL = "SELECT * FROM compra WHERE " + coluna + " LIKE \"%" + nome + "%\"";

            BancoDados.obterInstancia().conectar();
            MySqlCommand comandoSelecao = new MySqlCommand(SQL, BancoDados.obterInstancia().obterConexao());
            BancoDados.obterInstancia().iniciarTransacao();
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

            return Lista;
        }
    }
}
