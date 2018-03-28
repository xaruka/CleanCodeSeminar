using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DayTwo.DataManager.Sql
{
    public class SqlInsertDataCmd<TEntity> : IInsertDataCmd<SqlContext> where TEntity : IDataEntity
    {
        private readonly TEntity entity;

        public int InsertKey { get; private set; }

        public SqlInsertDataCmd(TEntity entity)
        {
            this.entity = entity;
        }

        public async Task ExecuteAsync(SqlContext context)
        {
            await context.Connection.ExecuteAsync(SqlQueryTypeCache<TEntity>.InsertQuery, entity);
            InsertKey = (await context.Connection.QueryAsync<int>("SELECT LAST_INSERT_ID()")).First();
        }
    }
}
