namespace DayTwo.DataManager
{
    public interface IDataCmdFactory<TEntity, in TContext> where TEntity : IDataEntity
    {
        IReadDataCmd<TEntity, TContext> CreateReadCommand();
        IInsertDataCmd<TContext> CreateInsertCommand(TEntity entity);
    }
}