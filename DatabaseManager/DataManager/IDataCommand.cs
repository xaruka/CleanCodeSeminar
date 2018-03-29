namespace DatabaseManager.DataManager
{
    internal interface IDataCommand<TEntity>
    {
        IDataCommandExecutor<TContext> MapToDataCommandExecutor<TContext>(IDataCommandExecutorFactory<TContext, TEntity> factory);
    }
}