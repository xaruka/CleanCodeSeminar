using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DatabaseManager.DataManager.Json
{
    internal class JsonReadCommandExecutor<TEntity> : IDataCommandExecutor<JsonContext>
    {
        private readonly Action<List<TEntity>> setListCallback;

        public JsonReadCommandExecutor(Action<List<TEntity>> setListCallback)
        {
            this.setListCallback = setListCallback;
        }

        public async Task Execute(JsonContext context)
        {
            var json = await context.File.ReadAllTextAsync();
            setListCallback(JsonConvert.DeserializeObject<List<TEntity>>(json));
        }
    }
}