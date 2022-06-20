using aaaaaaa.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Entidades
{
    class ItemCompra : Entidade
    {
        //constantes para representar os nomes dos atributos da tabela
        public const string ATRIBUTO_ID_COMPRA = "id_compra";
        public const string ATRIBUTO_NUMERO_ITEM = "numero_item";
        public const string ATRIBUTO_ID_PRODUTO = "id_produto";
        public const string ATRIBUTO_QUANTIDADE = "quantidade";
        public const string ATRIBUTO_VALOR_UNITARIO = "valor_unitario";
        public const string ATRIBUTO_TOTAL_ITEM = "total_item";

        //atributos
        public int idCompra { get; set; }
        public int numeroItem { get; set; }
        public int idProduto { get; set; }
        public int quantidade { get; set; }
        public double valorUnitario { get; set; }
        public double totalItem { get; set; }


        //sobrescrever os metodos transferirDados e transfirirDadosIdentificador para transferir
        //os valores de contato para os parametros de comando
        public override void transferirDados(MySqlCommand comando)
        {

            comando.Parameters[ATRIBUTO_ID_COMPRA].Value = idCompra;
            comando.Parameters[ATRIBUTO_NUMERO_ITEM].Value = numeroItem;
            comando.Parameters[ATRIBUTO_ID_PRODUTO].Value = idProduto;
            comando.Parameters[ATRIBUTO_QUANTIDADE].Value = quantidade;
            comando.Parameters[ATRIBUTO_VALOR_UNITARIO].Value = valorUnitario;
            comando.Parameters[ATRIBUTO_TOTAL_ITEM].Value = totalItem;

        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_COMPRA].Value = idCompra;
            comando.Parameters[ATRIBUTO_NUMERO_ITEM].Value = numeroItem;
        }

        //sobrescrever o metodo lerDados para ler os valores de contato para os parametros de leitorDados
        public override void lerDados(MySqlDataReader leitorDados)
        {
            idCompra = int.Parse(leitorDados[ATRIBUTO_ID_COMPRA].ToString());
            numeroItem = int.Parse(leitorDados[ATRIBUTO_NUMERO_ITEM].ToString());
            idProduto = int.Parse(leitorDados[ATRIBUTO_ID_PRODUTO].ToString());
            quantidade = int.Parse(leitorDados[ATRIBUTO_QUANTIDADE].ToString());
            valorUnitario = double.Parse(leitorDados[ATRIBUTO_VALOR_UNITARIO].ToString());
            totalItem = double.Parse(leitorDados[ATRIBUTO_TOTAL_ITEM].ToString());
        }
    }
}
