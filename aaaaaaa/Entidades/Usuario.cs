using aaaaaaa.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    class Usuario : Entidade
    {
        //constantes para representar os nomes dos atributos da tabela
        public const string ATRIBUTO_ID_USUARIO = "id_usuario";
        public const string ATRIBUTO_NOME = "nome";
        public const string ATRIBUTO_SENHA = "senha";

        //atributos
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }


        //sobrescrever os metodos transferirDados e transfirirDadosIdentificador para transferir
        //os valores de contato para os parametros de comando
        public override void transferirDados(MySqlCommand comando)
        {

            comando.Parameters[ATRIBUTO_ID_USUARIO].Value = idUsuario;
            comando.Parameters[ATRIBUTO_NOME].Value = nome;
            comando.Parameters[ATRIBUTO_SENHA].Value = senha;

        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_USUARIO].Value = idUsuario;
        }

        //sobrescrever o metodo lerDados para ler os valores de contato para os parametros de leitorDados
        public override void lerDados(MySqlDataReader leitorDados)
        {
            idUsuario = int.Parse(leitorDados[ATRIBUTO_ID_USUARIO].ToString());
            nome = leitorDados[ATRIBUTO_NOME].ToString();
            senha = leitorDados[ATRIBUTO_SENHA].ToString();
        }
    }
}
