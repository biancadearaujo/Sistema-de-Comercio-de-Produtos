using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Entidades;
using aaaaaaa.Persistencia;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Controladores
{
    class ControladorCadastroContasReceber : ControladorCadastro
    {
        override protected string criarComandoSelecao()
        {
            return "SELECT * FROM contareceber WHERE id_conta_receber = @id_conta_receber";
        }

        override protected string criarComandoInclusao()
        {
            return
                "INSERT INTO contareceber VALUES" +
                "(@id_conta_receber, @descricao, @id_cliente, " +
                " @data_lancamento, @data_vencimento, @valor," +
                " @recebido, @data_recebimento, @valor_recebimento)";
        }

        override protected string criarComandoAtualizacao()
        {
            return
                "UPDATE contareceber " +
                "SET descricao = @descricao, " +
                "id_cliente = @id_cliente, " +
                "data_lancamento = @data_lancamento, " +
                "data_vencimento = @data_vencimento, " +
                "valor = @valor, " +
                "recebido = @recebido, " +
                "data_recebimento = @data_recebimento, " +
                "valor_recebimento = @valor_recebimento" +
                "WHERE id_conta_receber = @id_conta_receber";
        }

        override protected string criarComandoExclusao()
        {
            return "DELETE FROM contareceber WHERE id_conta_receber = @id_conta_receber";
        }

        override protected void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(ContasReceber.ATRIBUTO_ID_CONTA_RECEBER, MySqlDbType.Int32);
            comando.Parameters.Add(ContasReceber.ATRIBUTO_DESCRICAO, MySqlDbType.VarChar);
            comando.Parameters.Add(ContasReceber.ATRIBUTO_ID_CLIENTE, MySqlDbType.Int32);
            comando.Parameters.Add(ContasReceber.ATRIBUTO_DATA_LANCAMENTO, MySqlDbType.Date);
            comando.Parameters.Add(ContasReceber.ATRIBUTO_DATA_VENCIMENTO, MySqlDbType.Date);
            comando.Parameters.Add(ContasReceber.ATRIBUTO_VALOR, MySqlDbType.Double);
            comando.Parameters.Add(ContasReceber.ATRIBUTO_RECEBIDO, MySqlDbType.VarChar);
            comando.Parameters.Add(ContasReceber.ATRIBUTO_DATA_RECEBIMENTO, MySqlDbType.Date);
            comando.Parameters.Add(ContasReceber.ATRIBUTO_VALOR_RECEBIMENTO, MySqlDbType.Double);
        }

        protected override void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(ContasReceber.ATRIBUTO_ID_CONTA_RECEBER, MySqlDbType.Int32);
        }

        public void incluir(Venda venda, String forma)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                String comando = "";

                if (forma == "Credito" || forma == "Boleto")
                {
                    comando = "INSERT INTO contareceber (id_conta_receber,descricao,id_cliente,data_lancamento,data_vencimento,valor,recebido) " +
                    "VALUES (" + venda.idVenda + ",'DEFAULT'," + venda.idCliente + ",'" + venda.data + "',DATE_ADD(CURDATE(), INTERVAL 30 DAY)," + venda.totalVenda + ",0)";
                }
                else
                {
                    comando = "INSERT INTO contareceber (id_conta_receber,descricao,id_cliente,data_lancamento,data_vencimento,valor,recebido,data_recebimento,valor_recebimento) " +
                   "VALUES (" + venda.idVenda + ",'DEFAULT'," + venda.idCliente + ",'" + venda.data + "',DATE_ADD(CURDATE(), INTERVAL 30 DAY)," + venda.totalVenda + ",1,'" + venda.data + "'," + venda.totalVenda + ")";
                }

                MySqlCommand comandoInclusao = new MySqlCommand(comando, BancoDados.obterInstancia().obterConexao());
                comandoInclusao.ExecuteNonQuery();
                BancoDados.obterInstancia().confirmarTransacao();
            }
            catch (Exception ex)
            {
                BancoDados.obterInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }

        public List<ContasReceber> buscarVendasRelatorio(String filterTipo)
        {
            List<ContasReceber> Lista = new List<ContasReceber>();
            String SQL = "SELECT * FROM contareceber WHERE 1=1 ";

            if (filterTipo == "a_receber")
            {
                SQL += "AND recebido = 0";
            }
            else if (filterTipo == "a_vencer")
            {
                SQL += "AND data_vencimento > CURRENT_DATE";
            }
            else if (filterTipo == "em_atraso")
            {
                SQL += "AND data_vencimento < CURRENT_DATE";
            }
            else if (filterTipo == "pagas")
            {
                SQL += "AND recebido = 1";
            }

            BancoDados.obterInstancia().conectar();
            MySqlCommand comandoSelecao = new MySqlCommand(SQL, BancoDados.obterInstancia().obterConexao());
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                MySqlDataReader leitorDados = comandoSelecao.ExecuteReader();
                while (leitorDados.Read())
                {
                    ContasReceber entidade = new ContasReceber();
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

        public List<Venda> buscarVendasBaixa()
        {
            List<Venda> Lista = new List<Venda>();
            String SQL = "SELECT venda.* FROM venda right join contareceber cr on (cr.id_conta_receber = venda.id_venda) where cr.recebido = 0";

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

        public void darBaixaVenda(String idVenda)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            String comando = "update contareceber set recebido = 1, data_recebimento = now(), valor_recebimento = valor where id_conta_receber = " + idVenda;
            MySqlCommand comandoUpdate = new MySqlCommand(comando, BancoDados.obterInstancia().obterConexao());
            comandoUpdate.ExecuteNonQuery();
            BancoDados.obterInstancia().confirmarTransacao();
        }
    }
}
