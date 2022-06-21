using System;
using System.Collections.Generic;
using System.Text;

using aaaaaaa.Persistencia;
using aaaaaaa.Entidades;
using MySql.Data.MySqlClient;
using System.Data;
namespace aaaaaaa.Controladores
{
    class ControladorCadastroMovimentacaoCaixa
    {
        public static int BuscarMaiorID()
        {
            MovimentacaoCaixa entidade = new MovimentacaoCaixa();
            String SQL = "SELECT * FROM movimentocaixa ORDER BY id_caixa DESC LIMIT 0, 1";

            BancoDados.obterInstancia().conectar();
            MySqlCommand comandoSelecao = new MySqlCommand(SQL, BancoDados.obterInstancia().obterConexao());
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                MySqlDataReader leitorDados = comandoSelecao.ExecuteReader();
                if (leitorDados.Read())
                {
                    entidade.lerDados(leitorDados);
                }
                else
                {
                    entidade.idCaixa = 0;
                }
                leitorDados.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            BancoDados.obterInstancia().desconectar();

            return entidade.idCaixa;
        }
    }
}
