using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    class ContasPagar : Entidade
    {
        public const string ATRIBUTO_ID_CONTA_PAGAR = "id_conta_pagar";
        public const string ATRIBUTO_DESCRICAO = "descricao";
        public const string ATRIBUTO_ID_FORNECEDOR = "id_fornecedor";
        public const string ATRIBUTO_DATA_LANCAMENTO = "data_lancamento";
        public const string ATRIBUTO_DATA_VENCIMENTO = "data_vencimento";
        public const string ATRIBUTO_VALOR = "valor";
        public const string ATRIBUTO_PAGO = "pago";
        public const string ATRIBUTO_DATA_PAGAMENTO = "data_pagamento";
        public const string ATRIBUTO_VALOR_PAGAMENTO = "valor_pagamento";

        public int idContaPagar { get; set; }
        public string descricao { get; set; }
        public int idFornecedor { get; set; }
        public string dataLancamento { get; set; }
        public string dataVencimento { get; set; }
        public double valor { get; set; }
        public string pago { get; set; }
        public string dataPagamento { get; set; }
        public double valorPagamento { get; set; }


        public override void transferirDados(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CONTA_PAGAR].Value = idContaPagar;
            comando.Parameters[ATRIBUTO_DESCRICAO].Value = descricao;
            comando.Parameters[ATRIBUTO_ID_FORNECEDOR].Value = idFornecedor;
            comando.Parameters[ATRIBUTO_DATA_LANCAMENTO].Value = dataLancamento;
            comando.Parameters[ATRIBUTO_DATA_VENCIMENTO].Value = dataVencimento;
            comando.Parameters[ATRIBUTO_VALOR].Value = valor;
            comando.Parameters[ATRIBUTO_PAGO].Value = pago;
            comando.Parameters[ATRIBUTO_DATA_PAGAMENTO].Value = dataPagamento;
            comando.Parameters[ATRIBUTO_VALOR_PAGAMENTO].Value = valorPagamento;
        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CONTA_PAGAR].Value = idContaPagar;
        }

        public override void lerDados(MySqlDataReader leitorDados)
        {
            idContaPagar = int.Parse(leitorDados[ATRIBUTO_ID_CONTA_PAGAR].ToString());
            descricao = leitorDados[ATRIBUTO_DESCRICAO].ToString();
            idFornecedor = int.Parse(leitorDados[ATRIBUTO_ID_FORNECEDOR].ToString());
            dataLancamento = leitorDados[ATRIBUTO_DATA_LANCAMENTO].ToString();
            dataVencimento = leitorDados[ATRIBUTO_DATA_VENCIMENTO].ToString();
            valor = double.Parse(leitorDados[ATRIBUTO_VALOR].ToString());
            pago = leitorDados[ATRIBUTO_PAGO].ToString();
            dataPagamento = leitorDados[ATRIBUTO_DATA_PAGAMENTO].ToString();
            valorPagamento = double.Parse(leitorDados[ATRIBUTO_VALOR_PAGAMENTO].ToString());
        }
    }
}
