namespace DayTwo.DataManager.Json
{
    public class JsonCmdFactory<TEntity> : IDataCmdFactory<TEntity, JsonFileContext> where TEntity : IDataEntity
    {
        public IReadDataCmd<TEntity, JsonFileContext> CreateReadCommand()
        {
            return new JsonReadDataCmd<TEntity>();
        }

        public IInsertDataCmd<JsonFileContext> CreateInsertCommand(TEntity entity)
        {
            return new JsonInsertDataCmd<TEntity>(entity);
        }
    }
}