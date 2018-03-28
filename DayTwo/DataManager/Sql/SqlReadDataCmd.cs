using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DayTwo.DataManager.Sql
{
    public class SqlReadDataCmd<TEntity> : IReadDataCmd<TEntity, SqlContext> where TEntity : IDataEntity
    {
        public IEnumerable<TEntity> DataList { get; private set; }

        public async Task ExecuteAsync(SqlContext context)
        {
            DataList = (await context.Connection.QueryAsync<TEntity>(SqlQueryTypeCache<TEntity>.SelectQuery)).ToList();
        }
    }
}
