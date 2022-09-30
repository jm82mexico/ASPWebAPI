using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Persitencia.DapperConexion
{
    public interface IFactoryConnection
    {
        void CloseConnection();

        IDbConnection GetConnection();
    }
}