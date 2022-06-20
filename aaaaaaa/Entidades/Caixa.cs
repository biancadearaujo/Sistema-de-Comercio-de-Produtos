using aaaaaaa.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    class Caixa : Entidade
    {
        //constantes para representar os nomes dos atributos da tabela
        public const string ATRIBUTO_ID_CAIXA = "id_caixa";
        public const string ATRIBUTO_NOME = "nome";
        public const string ATRIBUTO_SALDO = "saldo";

        //atributos
        public int idCaixa { get; set; }
        public string nome { get; set; }
        public double saldo { get; set; }


        //sobrescrever os metodos transferirDados e transfirirDadosIdentificador para transferir
        //os valores de contato para os parametros de comando
        public override void transferirDados(MySqlCommand comando)
        {

            comando.Parameters[ATRIBUTO_ID_CAIXA].Value = idCaixa;
            comando.Parameters[ATRIBUTO_NOME].Value = nome;
            comando.Parameters[ATRIBUTO_SALDO].Value = saldo;

        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CAIXA].Value = idCaixa;
        }

        //sobrescrever o metodo lerDados para ler os valores de contato para os parametros de leitorDados
        public override void lerDados(MySqlDataReader leitorDados)
        {
            idCaixa = int.Parse(leitorDados[ATRIBUTO_ID_CAIXA].ToString());
            nome = leitorDados[ATRIBUTO_NOME].ToString();
            saldo = double.Parse(leitorDados[ATRIBUTO_SALDO].ToString());
        }
    }
}