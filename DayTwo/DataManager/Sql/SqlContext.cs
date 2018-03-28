using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DayTwo.DataManager.Sql
{
    public class SqlContext
    {
        public IDbConnection Connection { get; set; }

        public SqlContext(IDbConnection connection)
        {
            Connection = connection;
        }
    }
}
