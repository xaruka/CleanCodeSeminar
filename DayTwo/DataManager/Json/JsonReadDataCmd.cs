using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DayTwo.DataManager.Json
{
    public class JsonReadDataCmd<TEntity> : IReadDataCmd<TEntity, JsonFileContext> where TEntity : IDataEntity
    {
        public IEnumerable<TEntity> DataList { get; private set; }
        public async Task ExecuteAsync(JsonFileContext context)
        {
            var json = await context.File.ReadAllTextAsync();
            DataList = JsonConvert.DeserializeObject<List<TEntity>>(json);
        }
    }
}