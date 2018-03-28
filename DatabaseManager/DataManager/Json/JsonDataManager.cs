using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DatabaseManager.DataManager.Json
{
    class JsonDataManager : IDataManager
    {
        private IDataCommandExecutorFactory<JsonContext, TEntity> CreateFactory<TEntity>()
        {
            return new JsonDataCommandExecutorFactory<TEntity>();
        }

        public async Task Execute<TEntity>(IDataCommand<TEntity> cmd)
        {
            var factory = CreateFactory<TEntity>();
            var executor = cmd.MapToDataCommandExecutor<JsonContext>(factory);
            await executor.Execute(new JsonContext());
        }
    }

    class JsonContext
    { }

    class JsonDataCommandExecutorFactory<TEntity> : IDataCommandExecutorFactory<JsonContext, TEntity>
    {
        public IDataCommandExecutor<JsonContext> CreateReadCommandExecutor(IDataListReceiver<TEntity> receiver)
        {
            return new JsonReadCommandExecutor<TEntity>(receiver);
        }
    }

    internal class JsonReadCommandExecutor<TEntity> : IDataCommandExecutor<JsonContext>
    {
        private IDataListReceiver<TEntity> receiver;

        public JsonReadCommandExecutor(IDataListReceiver<TEntity> receiver)
        {
            this.receiver = receiver;
        }

        public async Task Execute(JsonContext context)
        {
            var json = "[{Id:1337}]";
            receiver.SetDataList(JsonConvert.DeserializeObject<List<TEntity>>(json));
        }
    }
}
