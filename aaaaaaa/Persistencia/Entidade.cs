using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace aaaaaaa.Persistencia
{
    public abstract class Entidade
    {
        public abstract void transferirDados(MySqlCommand comando);

        public abstract void transferirDadosIdentificador(MySqlCommand comando);

        public abstract void lerDados(MySqlDataReader leitorDados);
    }
}
