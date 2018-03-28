using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo.DataManager.Json
{
    public class JsonDataManager : IDataManager<JsonFileContext>
    {
        private readonly FileInfo file;

        public JsonDataManager(FileInfo dbFile)
        {
            file = dbFile;
        }

        public async Task ExecuteAsync(IDataCmd<JsonFileContext> cmd)
        {
            await cmd.ExecuteAsync(new JsonFileContext(file));
        }

        public IDataCmdFactory<TEntity, JsonFileContext> CreateCmdFactory<TEntity>() where TEntity : IDataEntity
        {
            return new JsonCmdFactory<TEntity>();
        }
    }
}
