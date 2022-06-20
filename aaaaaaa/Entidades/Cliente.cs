using aaaaaaa.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    class Cliente : Entidade
    {
        //constantes para representar os nomes dos atributos da tabela
        public const string ATRIBUTO_ID_CLIENTE = "id_cliente";
        public const string ATRIBUTO_NOME = "nome";
        public const string ATRIBUTO_TELEFONE = "telefone";
        public const string ATRIBUTO_EMAIL = "email";
        public const string ATRIBUTO_RUA = "rua";
        public const string ATRIBUTO_NUMERO = "numero";
        public const string ATRIBUTO_COMPLEMENTO = "complemento";
        public const string ATRIBUTO_BAIRRO = "bairro";
        public const string ATRIBUTO_CIDADE = "cidade";
        public const string ATRIBUTO_UF = "uf";
        public const string ATRIBUTO_CEP = "cep";
        
        //atributos
        public int idCliente { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }


        //sobrescrever os metodos transferirDados e transfirirDadosIdentificador para transferir
        //os valores de contato para os parametros de comando
        public override void transferirDados(MySqlCommand comando)
        {

            comando.Parameters[ATRIBUTO_ID_CLIENTE].Value = idCliente;
            comando.Parameters[ATRIBUTO_NOME].Value = nome;
            comando.Parameters[ATRIBUTO_TELEFONE].Value = telefone;
            comando.Parameters[ATRIBUTO_EMAIL].Value = email;
            comando.Parameters[ATRIBUTO_RUA].Value = rua;
            comando.Parameters[ATRIBUTO_NUMERO].Value = numero;
            comando.Parameters[ATRIBUTO_COMPLEMENTO].Value = complemento;
            comando.Parameters[ATRIBUTO_BAIRRO].Value = bairro;
            comando.Parameters[ATRIBUTO_CIDADE].Value = cidade;
            comando.Parameters[ATRIBUTO_UF].Value = uf;
            comando.Parameters[ATRIBUTO_CEP].Value = cep;

        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CLIENTE].Value = idCliente;
        }

        //sobrescrever o metodo lerDados para ler os valores de contato para os parametros de leitorDados
        public override void lerDados(MySqlDataReader leitorDados)
        {
            idCliente = int.Parse(leitorDados[ATRIBUTO_ID_CLIENTE].ToString());
            nome = leitorDados[ATRIBUTO_NOME].ToString();
            telefone = leitorDados[ATRIBUTO_TELEFONE].ToString();
            email = leitorDados[ATRIBUTO_EMAIL].ToString();
            rua = leitorDados[ATRIBUTO_RUA].ToString();
            numero = leitorDados[ATRIBUTO_NUMERO].ToString();
            complemento = leitorDados[ATRIBUTO_COMPLEMENTO].ToString();
            bairro = leitorDados[ATRIBUTO_BAIRRO].ToString();
            cidade = leitorDados[ATRIBUTO_CIDADE].ToString();
            uf = leitorDados[ATRIBUTO_UF].ToString();
            cep = leitorDados[ATRIBUTO_CEP].ToString();
        }
    }
}
