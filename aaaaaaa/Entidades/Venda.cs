using aaaaaaa.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    class Venda : Entidade
    {
        //constantes para representar os nomes dos atributos da tabela
        public const string ATRIBUTO_ID_VENDA = "id_venda";
        public const string ATRIBUTO_DATA = "data";
        public const string ATRIBUTO_HORA = "hora";
        public const string ATRIBUTO_ID_CLIENTE = "id_cliente";
        public const string ATRIBUTO_TOTAL_VENDA = "total_venda";
        public const string ATRIBUTO_SITUACAO_VENDA = "situacao_venda";
        public const string ATRIBUTO_FORMA_PAGAMENTO = "forma_pagamento";

        //atributos
        public int idVenda { get; set; }
        public string data { get; set; }
        public string hora { get; set; }
        public int idCliente { get; set; }
        public double totalVenda { get; set; }
        public string situacaoVenda { get; set; }
        public string formaPagamento { get; set; }
        public List<ItemVenda> itens { get; set; }

        public Venda()
        {
            itens = new List<ItemVenda>();
        }


        //sobrescrever os metodos transferirDados e transfirirDadosIdentificador para transferir
        //os valores de contato para os parametros de comando
        public override void transferirDados(MySqlCommand comando)
        {

            comando.Parameters[ATRIBUTO_ID_VENDA].Value = idVenda;
            comando.Parameters[ATRIBUTO_DATA].Value = data;
            comando.Parameters[ATRIBUTO_HORA].Value = hora;
            comando.Parameters[ATRIBUTO_ID_CLIENTE].Value = idCliente;
            comando.Parameters[ATRIBUTO_TOTAL_VENDA].Value = totalVenda;
            comando.Parameters[ATRIBUTO_SITUACAO_VENDA].Value = situacaoVenda;
            comando.Parameters[ATRIBUTO_FORMA_PAGAMENTO].Value = formaPagamento;

        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_VENDA].Value = idVenda;
        }

        //sobrescrever o metodo lerDados para ler os valores de contato para os parametros de leitorDados
        public override void lerDados(MySqlDataReader leitorDados)
        {
            idVenda = int.Parse(leitorDados[ATRIBUTO_ID_VENDA].ToString());
            data = leitorDados[ATRIBUTO_DATA].ToString();
            hora = leitorDados[ATRIBUTO_HORA].ToString();
            idCliente = int.Parse(leitorDados[ATRIBUTO_ID_VENDA].ToString());
            totalVenda = double.Parse(leitorDados[ATRIBUTO_ID_VENDA].ToString());
            situacaoVenda = leitorDados[ATRIBUTO_SITUACAO_VENDA].ToString();
            formaPagamento = leitorDados[ATRIBUTO_FORMA_PAGAMENTO].ToString();
        }
    }
}
