using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DatabaseManager.DataManager.Sql
{
    class SqlContext
    {
        public IDbConnection Connection { get; }

        public SqlContext(IDbConnection connection)
        {
            Connection = connection;
        }
    }
}
