using System;
using System.Collections.Generic;
using System.Text;

namespace DayTwo.DataManager.Sql
{
    public class SqlCmdFactory<TEntity> : IDataCmdFactory<TEntity, SqlContext> where TEntity : IDataEntity
    {
        public IReadDataCmd<TEntity, SqlContext> CreateReadCommand()
        {
            return new SqlReadDataCmd<TEntity>();
        }

        public IInsertDataCmd<SqlContext> CreateInsertCommand(TEntity entity)
        {
            return new SqlInsertDataCmd<TEntity>(entity);
        }
    }
}
