using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DatabaseManager.DataManager.Sql
{
    class SqlInsertCommandExecutor<TEntity> : IDataCommandExecutor<SqlContext>
    {
        private readonly Action<int> setInsertKeyCallback;
        private readonly TEntity entity;

        public SqlInsertCommandExecutor(Action<int> setInsertKeyCallback, TEntity entity)
        {
            this.setInsertKeyCallback = setInsertKeyCallback;
            this.entity = entity;
        }

        public async Task Execute(SqlContext context)
        {
            await context.Connection.ExecuteAsync(SqlQueryTypeCache<TEntity>.InsertQuery, entity);
            var key = (await context.Connection.QueryAsync<int>("SELECT LAST_INSERT_ID()")).First();
            setInsertKeyCallback(key);
        }
    }
}
