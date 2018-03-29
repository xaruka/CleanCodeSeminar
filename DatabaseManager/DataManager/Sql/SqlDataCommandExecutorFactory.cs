using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseManager.DataManager.Sql
{
    class SqlDataCommandExecutorFactory<TEntity> : IDataCommandExecutorFactory<SqlContext, TEntity>
    {
        public IDataCommandExecutor<SqlContext> CreateReadCommandExecutor(Action<List<TEntity>> setListCallback)
        {
            return new SqlReadCommandExecutor<TEntity>(setListCallback);
        }

        public IDataCommandExecutor<SqlContext> CreateInsertCommandExecutor(Action<int> setInsertKeyCallback, TEntity entity)
        {
            return new SqlInsertCommandExecutor<TEntity>(setInsertKeyCallback, entity);
        }
    }
}
