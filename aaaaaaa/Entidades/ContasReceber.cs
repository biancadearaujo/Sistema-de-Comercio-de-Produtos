using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    public class ContasReceber : Entidade
    {
        public const string ATRIBUTO_ID_CONTA_RECEBER = "id_conta_receber";
        public const string ATRIBUTO_DESCRICAO = "descricao";
        public const string ATRIBUTO_ID_CLIENTE = "id_cliente";
        public const string ATRIBUTO_DATA_LANCAMENTO = "data_lancamento";
        public const string ATRIBUTO_DATA_VENCIMENTO = "data_vencimento";
        public const string ATRIBUTO_VALOR = "valor";
        public const string ATRIBUTO_RECEBIDO = "recebido";
        public const string ATRIBUTO_DATA_RECEBIMENTO = "data_recebimento";
        public const string ATRIBUTO_VALOR_RECEBIMENTO = "valor_recebimento";

        public int idContaReceber { get; set; }
        public string descricao { get; set; }
        public int idCliente { get; set; }
        public string dataLancamento { get; set; }
        public string dataVencimento { get; set; }
        public double valor { get; set; }
        public string recebido { get; set; }
        public string dataRecebimento { get; set; }
        public double valorRecebimento { get; set; }


        public override void transferirDados(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CONTA_RECEBER].Value = idContaReceber;
            comando.Parameters[ATRIBUTO_DESCRICAO].Value = descricao;
            comando.Parameters[ATRIBUTO_ID_CLIENTE].Value = idCliente;
            comando.Parameters[ATRIBUTO_DATA_LANCAMENTO].Value = dataLancamento;
            comando.Parameters[ATRIBUTO_DATA_VENCIMENTO].Value = dataVencimento;
            comando.Parameters[ATRIBUTO_VALOR].Value = valor;
            comando.Parameters[ATRIBUTO_RECEBIDO].Value = recebido;
            comando.Parameters[ATRIBUTO_DATA_RECEBIMENTO].Value = dataRecebimento;
            comando.Parameters[ATRIBUTO_VALOR_RECEBIMENTO].Value = valorRecebimento;
        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CONTA_RECEBER].Value = idContaReceber;
        }

        public override void lerDados(MySqlDataReader leitorDados)
        {
            idContaReceber = int.Parse(leitorDados[ATRIBUTO_ID_CONTA_RECEBER].ToString());
            descricao = leitorDados[ATRIBUTO_DESCRICAO].ToString();
            idCliente = int.Parse(leitorDados[ATRIBUTO_ID_CLIENTE].ToString());
            dataLancamento = leitorDados[ATRIBUTO_DATA_LANCAMENTO].ToString();
            dataVencimento = leitorDados[ATRIBUTO_DATA_VENCIMENTO].ToString();
            valor = double.Parse(leitorDados[ATRIBUTO_VALOR].ToString());
            recebido = leitorDados[ATRIBUTO_RECEBIDO].ToString();
            dataRecebimento = leitorDados[ATRIBUTO_DATA_RECEBIMENTO].ToString();
            valorRecebimento = double.Parse(leitorDados[ATRIBUTO_VALOR_RECEBIMENTO].ToString());
        }
    }
}
