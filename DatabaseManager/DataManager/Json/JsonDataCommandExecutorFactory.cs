using System;
using System.Collections.Generic;

namespace DatabaseManager.DataManager.Json
{
    internal class JsonDataCommandExecutorFactory<TEntity> : IDataCommandExecutorFactory<JsonContext, TEntity>
    {
        public IDataCommandExecutor<JsonContext> CreateReadCommandExecutor(Action<List<TEntity>> setListCallback)
        {
            return new JsonReadCommandExecutor<TEntity>(setListCallback);
        }

        public IDataCommandExecutor<JsonContext> CreateInsertCommandExecutor(Action<int> setInsertKeyCallback, TEntity entity)
        {
            return new JsonInsertCommandExecutor<TEntity>(setInsertKeyCallback, entity);
        }
    }
}