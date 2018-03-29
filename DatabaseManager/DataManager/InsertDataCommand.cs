namespace DatabaseManager.DataManager
{
    internal class InsertDataCommand<TEntity> : IDataCommand<TEntity>
    {
        private readonly TEntity entity;
        public int InsertKey { get; private set; }


        public InsertDataCommand(TEntity entity)
        {
            this.entity = entity;
        }

        public IDataCommandExecutor<TContext> MapToDataCommandExecutor<TContext>(IDataCommandExecutorFactory<TContext, TEntity> factory)
        {
            return factory.CreateInsertCommandExecutor(SetInsertKey, entity);
        }

        private void SetInsertKey(int key)
        {
            InsertKey = key;
        }
    }
}