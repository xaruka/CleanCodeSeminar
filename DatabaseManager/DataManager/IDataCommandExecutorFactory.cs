using System;
using System.Collections.Generic;

namespace DatabaseManager.DataManager
{
    internal interface IDataCommandExecutorFactory<TContext, TEntity>
    {
        IDataCommandExecutor<TContext> CreateReadCommandExecutor(Action<List<TEntity>> setListCallback);
        IDataCommandExecutor<TContext> CreateInsertCommandExecutor(Action<int> setInsertKeyCallback, TEntity entity);
    }
}