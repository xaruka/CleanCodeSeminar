using System.Collections.Generic;

namespace DayTwo.DataManager
{
    public interface IReadDataCmd<out TEntity, in TContext> : IDataCmd<TContext> where TEntity : IDataEntity
    {
        IEnumerable<TEntity> DataList { get; }
    }
}