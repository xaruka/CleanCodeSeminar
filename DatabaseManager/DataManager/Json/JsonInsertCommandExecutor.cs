using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DatabaseManager.DataManager.Json
{
    internal class JsonInsertCommandExecutor<TEntity> : IDataCommandExecutor<JsonContext>
    {
        private readonly Action<int> setInsertKeyCallback;
        private readonly TEntity entity;

        public JsonInsertCommandExecutor(Action<int> setInsertKeyCallback, TEntity entity)
        {
            this.setInsertKeyCallback = setInsertKeyCallback;
            this.entity = entity;
        }

        public async Task Execute(JsonContext context)
        {
            var json = await context.File.ReadAllTextAsync();
            var dataList = JsonConvert.DeserializeObject<List<TEntity>>(json) ?? new List<TEntity>();
            dataList.Add(entity);
            this.setInsertKeyCallback(1);
            await context.File.WriteAllTextAsync(JsonConvert.SerializeObject(dataList));
        }
    }
}