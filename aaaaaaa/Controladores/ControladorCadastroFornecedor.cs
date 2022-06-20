using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using aaaaaaa.Entidades;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Controladores
{
    class ControladorCadastroFornecedor : ControladorCadastro
    {

        //retornar selecao de contatos
        override protected string criarComandoSelecao()
        {
            return "SELECT * FROM fornecedor WHERE id_fornecedor = @id_fornecedor";
        }

        //retornar a inclusao de contatos
        override protected string criarComandoInclusao()
        {
            return "INSERT INTO fornecedor VALUES(@id_fornecedor, @nome, @telefone, @email, @rua, @numero, " +
                                                  "@complemento, @bairro, @cidade, @uf, @cep)";
        }

        //retornar a atualizacao de contato
        override protected string criarComandoAtualizacao()
        {
            return " UPDATE fornecedor " +
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
                   " WHERE  id_fornecedor = @id_fornecedor";
        }

        //retonar a exclusao do contato
        override protected string criarComandoExclusao()
        {
            return "DELETE FROM fornecedor WHERE id_fornecedor = @id_fornecerdor";
        }

        //retornar os paramentros referente as operacoes de inserir, atualizar, excluir e selecionar
        override protected void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(Fornecedor.ATRIBUTO_ID_FORNECEDOR, MySqlDbType.Int32);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_NOME, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_TELEFONE, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_EMAIL, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_RUA, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_NUMERO, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_COMPLEMENTO, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_BAIRRO, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_CIDADE, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_UF, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_CEP, MySqlDbType.String);
        }

        override protected void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(Fornecedor.ATRIBUTO_ID_FORNECEDOR, MySqlDbType.Int32);
        }

        public static int BuscarMaiorID()
        {
            Fornecedor entidade = new Fornecedor();
            String SQL = "SELECT * FROM fornecedor ORDER BY id_fornecedor DESC LIMIT 0, 1";

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
                    entidade.idFornecedor = 0;
                }
                leitorDados.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            BancoDados.obterInstancia().desconectar();

            return entidade.idFornecedor;
        }

    }
}
