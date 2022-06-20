using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using aaaaaaa.Entidades;
using MySql.Data.MySqlClient;
using System.Data;

namespace aaaaaaa.Controladores
{
    class ControladorCadastroCliente : ControladorCadastro
    {
        //retornar selecao de contatos
        override protected string criarComandoSelecao()
        {
            return "SELECT * FROM cliente WHERE id_cliente = @id_cliente";
        }

        //retornar a inclusao de contatos
        override protected string criarComandoInclusao()
        {
            return "INSERT INTO cliente VALUES(@id_cliente, @nome, @telefone, @email, @rua, @numero, " +
                                                  "@complemento, @bairro, @cidade, @uf, @cep)";
        }

        //retornar a atualizacao de contato
        override protected string criarComandoAtualizacao()
        {
            return " UPDATE cliente " +
                   " SET    nome = @nome, " +
                   "        telefone = @telefone, " +
                   "        email = @email " +
                   "        rua = @rua " +
                   "        numero = @numero " +
                   "        complemento = @complemento " +
                   "        bairro = @bairro " +
                   "        cidade = @cidade " +
                   "        uf = @uf " +
                   "        cep = @cep " +
                   " WHERE  id_cliente = @id_cliente";
        }

        //retonar a exclusao do contato
        override protected string criarComandoExclusao()
        {
            return "DELETE FROM cliente WHERE id_cliente = @id_cliente";
        }

        //retornar os paramentros referente as operacoes de inserir, atualizar, excluir e selecionar
        override protected void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(Cliente.ATRIBUTO_ID_CLIENTE, MySqlDbType.Int32);
            comando.Parameters.Add(Cliente.ATRIBUTO_NOME, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_TELEFONE, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_EMAIL, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_RUA, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_NUMERO, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_COMPLEMENTO, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_BAIRRO, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_CIDADE, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_UF, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_CEP, MySqlDbType.String);
        }

        override protected void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(Cliente.ATRIBUTO_ID_CLIENTE, MySqlDbType.Int32);
        }

        public static int BuscarMaiorID()
        {
            Cliente entidade = new Cliente();
            String SQL = "SELECT * FROM cliente ORDER BY id_cliente DESC LIMIT 0, 1";

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
                    entidade.idCliente = 0;
                }
                leitorDados.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            BancoDados.obterInstancia().desconectar();

            return entidade.idCliente;
        }
    }
}
