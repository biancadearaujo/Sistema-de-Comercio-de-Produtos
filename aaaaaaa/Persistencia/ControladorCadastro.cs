using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Persistencia
{
    //operacoes de incluir, alterar, exclusao e selecao de uma entidade
    public abstract class ControladorCadastro
    {
            //execusao de comandos sql
            private MySqlCommand comandoInclusao;
            private MySqlCommand comandoAtualizacao;
            private MySqlCommand comandoExclusao;
            private MySqlCommand comandoSelecao;

            public ControladorCadastro()
            {
                comandoInclusao = new MySqlCommand(criarComandoInclusao(), BancoDados.obterInstancia().obterConexao());
                comandoAtualizacao = new MySqlCommand(criarComandoAtualizacao(), BancoDados.obterInstancia().obterConexao());
                comandoExclusao = new MySqlCommand(criarComandoExclusao(), BancoDados.obterInstancia().obterConexao());
                comandoSelecao = new MySqlCommand(criarComandoSelecao(), BancoDados.obterInstancia().obterConexao());
                criarParametrosInclusao(comandoInclusao);
                criarParametrosAtualizacao(comandoAtualizacao);
                criarParametrosChavePrimaria(comandoExclusao);
                criarParametrosChavePrimaria(comandoSelecao);
            }

            protected abstract string criarComandoSelecao();
            protected abstract string criarComandoInclusao();
            protected abstract string criarComandoAtualizacao();
            protected abstract string criarComandoExclusao();

            //criacao dos parametros referentes as operacoes a serem realizadas pelo controlador
            protected abstract void criarParametros(MySqlCommand comando);

            protected abstract void criarParametrosChavePrimaria(MySqlCommand comandoExclusao);

            //metodo para preparar os parametros a serem usados para inclusao, alteracao
            protected virtual void criarParametrosInclusao(MySqlCommand comandoInclusao)
            {
                criarParametros(comandoInclusao);
            }
            protected virtual void criarParametrosAtualizacao(MySqlCommand comandoAtualizacao)
            {
                criarParametros(comandoAtualizacao);
            }

            //metodo para selecionar entidade
            public void selecionar(Entidade entidade)
            {
                BancoDados.obterInstancia().iniciarTransacao();
                try
                {
                    entidade.transferirDadosIdentificador(comandoSelecao);
                    MySqlDataReader leitorDados = (MySqlDataReader)comandoSelecao.ExecuteReader();
                    while (leitorDados.Read())
                    {
                        entidade.lerDados(leitorDados);
                    }
                    leitorDados.Close();
                    BancoDados.obterInstancia().confirmarTransacao();
                }
                catch (Exception ex)
                {
                    BancoDados.obterInstancia().cancelarTransacao();
                    throw new Exception(ex.Message);
                }
            }

            //metodo incluir entidade
            public void incluir(Entidade entidade)
            {
                BancoDados.obterInstancia().iniciarTransacao();
                try
                {
                    entidade.transferirDados(comandoInclusao);
                    comandoInclusao.ExecuteNonQuery();
                    BancoDados.obterInstancia().confirmarTransacao();
                }
                catch (Exception ex)
                {
                    BancoDados.obterInstancia().cancelarTransacao();
                    throw new Exception(ex.Message);
                }
            }

            //metodo para alterar uma entidade
            public void atualizar(Entidade entidade)
            {
                BancoDados.obterInstancia().iniciarTransacao();
                try
                {
                    entidade.transferirDados(comandoAtualizacao);
                    comandoAtualizacao.ExecuteNonQuery();
                    BancoDados.obterInstancia().confirmarTransacao();
                }
                catch (Exception ex)
                {
                    BancoDados.obterInstancia().cancelarTransacao();
                    throw new Exception(ex.Message);
                }
            }

            //metodo para excluir uma entidade
            public void excluir(Entidade entidade)
            {
                BancoDados.obterInstancia().iniciarTransacao();
                try
                {
                    entidade.transferirDadosIdentificador(comandoExclusao);
                    comandoExclusao.ExecuteNonQuery();
                    BancoDados.obterInstancia().confirmarTransacao();
                }
                catch (Exception ex)
                {
                    BancoDados.obterInstancia().cancelarTransacao();
                    throw new Exception(ex.Message);
                }
            }
        }
}
