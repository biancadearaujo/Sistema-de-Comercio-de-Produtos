using aaaaaaa.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    class Compra : Entidade
    {
        //constantes para representar os nomes dos atributos da tabela
        public const string ATRIBUTO_ID_COMPRA = "id_compra";
        public const string ATRIBUTO_DATA = "data";
        public const string ATRIBUTO_HORA = "hora";
        public const string ATRIBUTO_ID_FORNECEDOR = "id_fornecedor";
        public const string ATRIBUTO_TOTAL_COMPRA = "total_compra";
        public const string ATRIBUTO_SITUACAO_COMPRA = "situacao_compra";
        public const string ATRIBUTO_FORMA_PAGAMENTO = "forma_pagamento";

        //atributos
        public int idCompra { get; set; }
        public string data { get; set; }
        public string hora { get; set; }
        public int idFornecedor { get; set; }
        public double totalCompra { get; set; }
        public string situacaoCompra { get; set; }
        public string formaPagamento { get; set; }

        public List<ItemCompra> itens { get; set; }

        public Compra()
        {
            itens = new List<ItemCompra>();
        }


        //sobrescrever os metodos transferirDados e transfirirDadosIdentificador para transferir
        //os valores de contato para os parametros de comando
        public override void transferirDados(MySqlCommand comando)
        {

            comando.Parameters[ATRIBUTO_ID_COMPRA].Value = idCompra;
            comando.Parameters[ATRIBUTO_DATA].Value = data;
            comando.Parameters[ATRIBUTO_HORA].Value = hora;
            comando.Parameters[ATRIBUTO_ID_FORNECEDOR].Value = idFornecedor;
            comando.Parameters[ATRIBUTO_TOTAL_COMPRA].Value = totalCompra;
            comando.Parameters[ATRIBUTO_SITUACAO_COMPRA].Value = situacaoCompra;
            comando.Parameters[ATRIBUTO_FORMA_PAGAMENTO].Value = formaPagamento;

        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_COMPRA].Value = idCompra;
        }

        //sobrescrever o metodo lerDados para ler os valores de contato para os parametros de leitorDados
        public override void lerDados(MySqlDataReader leitorDados)
        {
            idCompra = int.Parse(leitorDados[ATRIBUTO_ID_COMPRA].ToString());
            data = leitorDados[ATRIBUTO_DATA].ToString();
            hora = leitorDados[ATRIBUTO_HORA].ToString();
            idFornecedor = int.Parse(leitorDados[ATRIBUTO_ID_FORNECEDOR].ToString());
            totalCompra = double.Parse(leitorDados[ATRIBUTO_TOTAL_COMPRA].ToString());
            situacaoCompra = leitorDados[ATRIBUTO_SITUACAO_COMPRA].ToString();
            formaPagamento = leitorDados[ATRIBUTO_FORMA_PAGAMENTO].ToString();
        }
    }
}
