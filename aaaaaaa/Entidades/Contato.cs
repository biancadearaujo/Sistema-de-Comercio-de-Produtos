using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    class Contato : Entidade
    {
        //constantes para representar os nomes dos atributos da tabela
        public const string ATRIBUTO_ID_CONTATO = "ID_CONTATO";
        public const string ATRIBUTO_NOME = "NOME";
        public const string ATRIBUTO_EMAIL = "EMAIL";
        public const string ATRIBUTO_TELEFONE = "TELEFONE";

        //atributos
        public int idContato { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }

        //sobrescrever os metodos transferirDados e transfirirDadosIdentificador para transferir
        //os valores de contato para os parametros de comando
        public override void transferirDados(MySqlCommand comando)
        {

            comando.Parameters[ATRIBUTO_ID_CONTATO].Value = idContato;
            comando.Parameters[ATRIBUTO_NOME].Value = nome;
            comando.Parameters[ATRIBUTO_EMAIL].Value = email;
            comando.Parameters[ATRIBUTO_TELEFONE].Value = telefone;

        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CONTATO].Value = idContato;
        }

        //sobrescrever o metodo lerDados para ler os valores de contato para os parametros de leitorDados
        public override void lerDados(MySqlDataReader leitorDados)
        {
            idContato = int.Parse(leitorDados[ATRIBUTO_ID_CONTATO].ToString());
            nome = leitorDados[ATRIBUTO_NOME].ToString();
            email = leitorDados[ATRIBUTO_EMAIL].ToString();
            telefone = leitorDados[ATRIBUTO_TELEFONE].ToString();
        }
    }
}
