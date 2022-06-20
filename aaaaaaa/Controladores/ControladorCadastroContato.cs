using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using aaaaaaa.Entidades;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Controladores
{
    public class ControladorCadastroContato : ControladorCadastro
    {
        
        //retornar selecao de contatos
        override protected string criarComandoSelecao()
        {
            return "SELECT * FROM CONTATO WHERE ID_CONTATO = @ID_CONTATO";
        }

        //retornar a inclusao de contatos
        override protected string criarComandoInclusao()
        {
            return "INSERT INTO CONTATO VALUES(@ID_CONTATO, @NOME, @EMAIL, @TELEFONE)";
        }

        //retornar a atualizacao de contato
        override protected string criarComandoAtualizacao()
        {
            return " UPDATE CONTATO " +
                   " SET    NOME = @NOME, " +
                   "        EMAIL = @EMAIL, " +
                   "        TELEFONE = @TELEFONE " +
                   " WHERE  ID_CONTATO = @ID_CONTATO";
        }

        //retonar a exclusao do contato
        override protected string criarComandoExclusao()
        {
            return "DELETE FROM CONTATO WHERE ID_CONTATO = @ID_CONTATO";
        }

        //retornar os paramentros referente as operacoes de inserir, atualizar, excluir e selecionar
        override protected void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(Contato.ATRIBUTO_ID_CONTATO, MySqlDbType.Int32);
            comando.Parameters.Add(Contato.ATRIBUTO_NOME, MySqlDbType.String);
            comando.Parameters.Add(Contato.ATRIBUTO_EMAIL, MySqlDbType.String);
            comando.Parameters.Add(Contato.ATRIBUTO_TELEFONE, MySqlDbType.String);
        }

        override protected void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(Contato.ATRIBUTO_ID_CONTATO, MySqlDbType.Int32);
        }
    }
}
