using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DayTwo.DataManager.Json
{
    public class JsonInsertDataCmd<TEntity> : IInsertDataCmd<JsonFileContext> where TEntity : class, IDataEntity
    {
        private readonly TEntity entity;

        public int InsertKey { get; private set; }

        public JsonInsertDataCmd(TEntity entity)
        {
            this.entity = entity;
        }

        public async Task ExecuteAsync(JsonFileContext context)
        {
            var json = await context.File.ReadAllTextAsync();
            var dataList = JsonConvert.DeserializeObject<List<TEntity>>(json) ?? new List<TEntity>();
            dataList.Add(entity);
            InsertKey = entity.EntityId = dataList.Max(e => e.EntityId) + 1;
            await context.File.WriteAllTextAsync(JsonConvert.SerializeObject(dataList));
        }
    }
}