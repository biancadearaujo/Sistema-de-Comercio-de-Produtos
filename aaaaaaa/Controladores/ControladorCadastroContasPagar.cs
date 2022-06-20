using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Entidades;
using aaaaaaa.Persistencia;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Controladores
{
    class ControladorCadastroContasPagar : ControladorCadastro
    {
        override protected string criarComandoSelecao()
        {
            return "SELECT * FROM contapagar WHERE id_conta_pagar = @id_conta_pagar";
        }

        override protected string criarComandoInclusao()
        {
            return
                "INSERT INTO contapagar VALUES" +
                "(@id_conta_pagar, @descricao, @id_fornecedor, " +
                " @data_lancamento, @data_vencimento, @valor," +
                " @pago, @data_pagamento, @valor_pagamento)";
        }

        override protected string criarComandoAtualizacao()
        {
            return
                "UPDATE contapagar " +
                "SET descricao = @descricao, " +
                "id_fornecedor = @id_fornecedor, " +
                "data_lancamento = @data_lancamento, " +
                "data_vencimento = @data_vencimento, " +
                "valor = @valor, " +
                "pago = @pago, " +
                "data_pagamento = @data_pagamento, " +
                "valor_pagamento = @valor_pagamento" +
                "WHERE id_conta_pagar = @id_conta_pagar";
        }

        override protected string criarComandoExclusao()
        {
            return "DELETE FROM contapagar WHERE id_conta_pagar = @id_conta_pagar";
        }

        override protected void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(ContasPagar.ATRIBUTO_ID_CONTA_PAGAR, MySqlDbType.Int32);
            comando.Parameters.Add(ContasPagar.ATRIBUTO_DESCRICAO, MySqlDbType.VarChar);
            comando.Parameters.Add(ContasPagar.ATRIBUTO_ID_FORNECEDOR, MySqlDbType.Int32);
            comando.Parameters.Add(ContasPagar.ATRIBUTO_DATA_LANCAMENTO, MySqlDbType.Date);
            comando.Parameters.Add(ContasPagar.ATRIBUTO_DATA_VENCIMENTO, MySqlDbType.Date);
            comando.Parameters.Add(ContasPagar.ATRIBUTO_VALOR, MySqlDbType.Double);
            comando.Parameters.Add(ContasPagar.ATRIBUTO_PAGO, MySqlDbType.VarChar);
            comando.Parameters.Add(ContasPagar.ATRIBUTO_DATA_PAGAMENTO, MySqlDbType.Date);
            comando.Parameters.Add(ContasPagar.ATRIBUTO_VALOR_PAGAMENTO, MySqlDbType.Double);
        }

        protected override void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(ContasPagar.ATRIBUTO_ID_CONTA_PAGAR, MySqlDbType.Int32);
        }

        public void incluir(Compra compra, String forma)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                String comando = "";

                if (forma == "Credito" || forma == "Boleto")
                {
                    comando = "INSERT INTO contapagar (id_conta_pagar,descricao,id_fornecedor,data_lancamento,data_vencimento,valor,pago) " +
                    "VALUES (" + compra.idCompra + ",'DEFAULT'," + compra.idFornecedor + ",'" + compra.data + "',DATE_ADD(CURDATE(), INTERVAL 30 DAY)," + compra.totalCompra + ",0)";
                }
                else
                {
                    comando = "INSERT INTO contapagar (id_conta_pagar,descricao,id_fornecedor,data_lancamento,data_vencimento,valor,pago,data_pagamento,valor_pagamento) " +
                   "VALUES (" + compra.idCompra + ",'DEFAULT'," + compra.idFornecedor + ",'" + compra.data + "',DATE_ADD(CURDATE(), INTERVAL 30 DAY)," + compra.totalCompra + ",1,'" + compra.data + "'," + compra.totalCompra + ")";
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

        public List<ContasPagar> buscarComprasRelatorio(String filterTipo)
        {
            ///perguntar o rafael sobre o sql
            List<ContasPagar> Lista = new List<ContasPagar>();
            String SQL = "SELECT * FROM contapagar WHERE 1=1 ";

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
                    ContasPagar entidade = new ContasPagar();
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

        public List<Compra> buscarComprasBaixa()
        {
            List<Compra> Lista = new List<Compra>();
            String SQL = "SELECT compra.* FROM compra left join contapagar cr on (cr.id_conta_pagar = compra.id_compra) where cr.pago = 0";

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

        public void darBaixaCompra(String idCompra)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            String comando = "update contapagar set pago = 1, data_pagamento = now(), valor_pagamento = valor where id_conta_pagar = " + idCompra;
            MySqlCommand comandoUpdate = new MySqlCommand(comando, BancoDados.obterInstancia().obterConexao());
            comandoUpdate.ExecuteNonQuery();
            BancoDados.obterInstancia().confirmarTransacao();
        }
    }
}
