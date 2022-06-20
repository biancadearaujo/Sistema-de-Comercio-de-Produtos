using aaaaaaa.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;


namespace aaaaaaa.Entidades
{
    public class Produto : Entidade
    {
        public const string ATRIBUTO_ID_PRODUTO = "id_produto";
        public const string ATRIBUTO_NOME = "nome";
        public const string ATRIBUTO_QUANTIDADE_ESTOQUE = "quantidade_estoque";
        public const string ATRIBUTO_PRECO = "preco";
        public const string ATRIBUTO_UNIDADE = "unidade";
        public const string ATRIBUTO_ID_FORNECEDOR = "id_fornecedor";

        public int idProduto { get; set; }
        public string nome { get; set; }
        public int quantidadeEstoque { get; set; }
        public double preco { get; set; }
        public string unidade { get; set; }
        public double idFornecedor { get; set; }
        public int quantidade { get; set; }


        public override void transferirDados(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_PRODUTO].Value = idProduto;
            comando.Parameters[ATRIBUTO_NOME].Value = nome;
            comando.Parameters[ATRIBUTO_QUANTIDADE_ESTOQUE].Value = quantidadeEstoque;
            comando.Parameters[ATRIBUTO_PRECO].Value = preco;
            comando.Parameters[ATRIBUTO_UNIDADE].Value = unidade;
            comando.Parameters[ATRIBUTO_ID_FORNECEDOR].Value = idFornecedor;
        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_PRODUTO].Value = idProduto;
        }

        public override void lerDados(MySqlDataReader leitorDados)
        {
            idProduto = int.Parse(leitorDados[ATRIBUTO_ID_PRODUTO].ToString());
            nome = leitorDados[ATRIBUTO_NOME].ToString();
            quantidadeEstoque = int.Parse(leitorDados[ATRIBUTO_QUANTIDADE_ESTOQUE].ToString());
            preco = double.Parse(leitorDados[ATRIBUTO_PRECO].ToString());
            unidade = leitorDados[ATRIBUTO_UNIDADE].ToString();
            idFornecedor = int.Parse(leitorDados[ATRIBUTO_ID_FORNECEDOR].ToString());
        }
    }
}
