using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using aaaaaaa.Entidades;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Controladores
{
    class ControladorCadastroProduto : ControladorCadastro
    {
        //retornar selecao de contatos
        override protected string criarComandoSelecao()
        {
            return "SELECT * FROM produto WHERE id_produto = @id_produto";
        }

        //retornar a inclusao de contatos
        override protected string criarComandoInclusao()
        {
            return "INSERT INTO produto VALUES(@id_produto, @nome, @quantidade_estoque, @preco, @unidade, @id_fornecedor)";
        }

        //retornar a atualizacao de contato
        override protected string criarComandoAtualizacao()
        {
            return " UPDATE produto " +
                   " SET    nome = @nome, " +
                   "        quantidade_estoque = @quantidade_estoque, " +
                   "        preco = @preco " +
                   "        unidade = @unidade " +
                   "        id_fornecedor = @id_fornecedor " +
                   " WHERE  id_produto = @id_produto";
        }

        //retonar a exclusao do contato
        override protected string criarComandoExclusao()
        {
            return "DELETE FROM produto WHERE id_produto = @id_produto";
        }

        //retornar os paramentros referente as operacoes de inserir, atualizar, excluir e selecionar
        override protected void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(Produto.ATRIBUTO_ID_PRODUTO, MySqlDbType.Int32);
            comando.Parameters.Add(Produto.ATRIBUTO_NOME, MySqlDbType.String);
            comando.Parameters.Add(Produto.ATRIBUTO_QUANTIDADE_ESTOQUE, MySqlDbType.Int32);
            comando.Parameters.Add(Produto.ATRIBUTO_PRECO, MySqlDbType.Double);
            comando.Parameters.Add(Produto.ATRIBUTO_UNIDADE, MySqlDbType.String);
            comando.Parameters.Add(Produto.ATRIBUTO_ID_FORNECEDOR, MySqlDbType.Int32);
        }

        override protected void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(Produto.ATRIBUTO_ID_PRODUTO, MySqlDbType.Int32);
        }

        public static int BuscarMaiorID()
        {
            Produto entidade = new Produto();
            String SQL = "SELECT * FROM produto ORDER BY id_produto DESC LIMIT 0, 1";

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
                    entidade.idProduto = 0;
                }
                leitorDados.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            BancoDados.obterInstancia().desconectar();

            return entidade.idProduto;
        }
    }
}
