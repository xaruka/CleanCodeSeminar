using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.DataManager
{
    interface IDataManager
    {
        Task Execute<TEntity>(IDataCommand<TEntity> cmd);
    }

    internal interface IDataCommandExecutor<TContext>
    {
        Task Execute(TContext context);
    }
    

    internal interface IDataListReceiver<TEntity>
    {
        void SetDataList(List<TEntity> dataList);
    }

    internal interface IDataCommand<TEntity>
    {
        IDataCommandExecutor<TContext> MapToDataCommandExecutor<TContext>(IDataCommandExecutorFactory<TContext, TEntity> factory);
    }

    internal interface IDataCommandExecutorFactory<TContext, TEntity>
    {
        IDataCommandExecutor<TContext> CreateReadCommandExecutor(IDataListReceiver<TEntity> receiver);
    }

    class ReadDataCommand<TEntity> : IDataCommand<TEntity>, IDataListReceiver<TEntity>
    {
        public IEnumerable<TEntity> Data { get; private set; }

        public IDataCommandExecutor<TContext> MapToDataCommandExecutor<TContext>(IDataCommandExecutorFactory<TContext, TEntity> factory)
        {
            return factory.CreateReadCommandExecutor(this);
        }

        void IDataListReceiver<TEntity>.SetDataList(List<TEntity> dataList)
        {
            Data = dataList;
        }
    }
}
