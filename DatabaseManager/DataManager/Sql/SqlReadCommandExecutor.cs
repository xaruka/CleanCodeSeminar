using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DatabaseManager.DataManager.Sql
{
    class SqlReadCommandExecutor<TEntity> : IDataCommandExecutor<SqlContext>
    {
        private readonly Action<List<TEntity>> setListCallback;

        public SqlReadCommandExecutor(Action<List<TEntity>> setListCallback)
        {
            this.setListCallback = setListCallback;
        }

        public async Task Execute(SqlContext context)
        {
            var result = await context.Connection.QueryAsync<TEntity>(SqlQueryTypeCache<TEntity>.SelectQuery);
            setListCallback(result.ToList());
        }
    }
}
