using System.IO;
using System.Threading.Tasks;

namespace DatabaseManager.DataManager.Json
{
    internal class JsonDataManager : IDataManager
    {
        private readonly FileInfo dbFile;

        public JsonDataManager(FileInfo dbFile)
        {
            this.dbFile = dbFile;
        }
        
        public async Task Execute<TEntity>(IDataCommand<TEntity> cmd)
        {
            var executor = cmd.MapToDataCommandExecutor(new JsonDataCommandExecutorFactory<TEntity>());
            await executor.Execute(new JsonContext(dbFile));
        }
    }
}
