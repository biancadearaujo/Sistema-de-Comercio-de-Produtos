using aaaaaaa.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    class MovimentacaoCaixa : Entidade
    {
        //constantes para representar os nomes dos atributos da tabela
        public const string ATRIBUTO_ID_CAIXA = "id_caixa";
        public const string ATRIBUTO_NUMERO_MOVIMENTO = "numero_movimento";
        public const string ATRIBUTO_DATA_MOVIMENTO = "data_movimento";
        public const string ATRIBUTO_HORA_MOVIMENTO = "hora_movimento";
        public const string ATRIBUTO_DESCRICAO = "descricao";
        public const string ATRIBUTO_TIPO_MOVIMENTO = "tipo_movimento";
        public const string ATRIBUTO_VALOR = "valor";

        //atributos
        public int idCaixa { get; set; }
        public int numeroMovimento { get; set; }
        public string dataMovimento { get; set; }
        public string horaMovimento { get; set; }
        public string descricao { get; set; }
        public string tipoMovimento { get; set; }
        public double valor { get; set; }


        //sobrescrever os metodos transferirDados e transfirirDadosIdentificador para transferir
        //os valores de contato para os parametros de comando
        public override void transferirDados(MySqlCommand comando)
        {

            comando.Parameters[ATRIBUTO_ID_CAIXA].Value = idCaixa;
            comando.Parameters[ATRIBUTO_NUMERO_MOVIMENTO].Value = numeroMovimento;
            comando.Parameters[ATRIBUTO_DATA_MOVIMENTO].Value = dataMovimento;
            comando.Parameters[ATRIBUTO_HORA_MOVIMENTO].Value = horaMovimento;
            comando.Parameters[ATRIBUTO_DESCRICAO].Value = descricao;
            comando.Parameters[ATRIBUTO_TIPO_MOVIMENTO].Value = tipoMovimento;
            comando.Parameters[ATRIBUTO_VALOR].Value = valor;

        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CAIXA].Value = idCaixa;
        }

        //sobrescrever o metodo lerDados para ler os valores de contato para os parametros de leitorDados
        public override void lerDados(MySqlDataReader leitorDados)
        {
            idCaixa = int.Parse(leitorDados[ATRIBUTO_ID_CAIXA].ToString());
            numeroMovimento = int.Parse(leitorDados[ATRIBUTO_NUMERO_MOVIMENTO].ToString());
            dataMovimento = leitorDados[ATRIBUTO_DATA_MOVIMENTO].ToString();
            horaMovimento = leitorDados[ATRIBUTO_HORA_MOVIMENTO].ToString();
            descricao = leitorDados[ATRIBUTO_DESCRICAO].ToString();
            tipoMovimento = leitorDados[ATRIBUTO_TIPO_MOVIMENTO].ToString();
            valor = double.Parse(leitorDados[ATRIBUTO_VALOR].ToString());
        }
    }
}
