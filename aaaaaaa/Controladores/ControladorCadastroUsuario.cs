using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using aaaaaaa.Entidades;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Controladores
{
    class ControladorCadastroUsuario : ControladorCadastro
    {
        //retornar selecao de contatos
        override protected string criarComandoSelecao()
        {
            return "SELECT * FROM usuario WHERE id_usuario = @id_usuario";
        }

        //retornar a inclusao de contatos
        override protected string criarComandoInclusao()
        {
            return "INSERT INTO usuario VALUES(@id_usuario, @nome, @senha)";
        }

        //retornar a atualizacao de contato
        override protected string criarComandoAtualizacao()
        {
            return " UPDATE usuario " +
                   " SET    nome = @nome, " +
                   "        senha = @senha " +
                   " WHERE  id_usuario = @id_usuario";
        }

        //retonar a exclusao do contato
        override protected string criarComandoExclusao()
        {
            return "DELETE FROM usuario WHERE id_usuario = @id_usuario";
        }

        //retornar os paramentros referente as operacoes de inserir, atualizar, excluir e selecionar
        override protected void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(Usuario.ATRIBUTO_ID_USUARIO, MySqlDbType.Int32);
            comando.Parameters.Add(Usuario.ATRIBUTO_NOME, MySqlDbType.String);
            comando.Parameters.Add(Usuario.ATRIBUTO_SENHA, MySqlDbType.String);
        }

        override protected void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(Usuario.ATRIBUTO_ID_USUARIO, MySqlDbType.Int32);
        }

        public static int BuscarMaiorID()
        {
            Usuario entidade = new Usuario();
            String SQL = "SELECT * FROM usuario ORDER BY id_usuario DESC LIMIT 0, 1";

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
                    entidade.idUsuario = 0;
                }
                leitorDados.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            BancoDados.obterInstancia().desconectar();

            return entidade.idUsuario;
        }
    }
}
