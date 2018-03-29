using System.Collections.Generic;

namespace DatabaseManager.DataManager
{
    internal class ReadDataCommand<TEntity> : IDataCommand<TEntity>
    {
        public IEnumerable<TEntity> Data { get; private set; }

        public IDataCommandExecutor<TContext> MapToDataCommandExecutor<TContext>(IDataCommandExecutorFactory<TContext, TEntity> factory)
        {
            return factory.CreateReadCommandExecutor(SetDataList);
        }

        private void SetDataList(List<TEntity> dataList)
        {
            Data = dataList;
        }
    }
}