namespace DayTwo.DataManager
{
    public interface IInsertDataCmd<in TContext> : IDataCmd<TContext>
    {
        int InsertKey { get; }
    }
}