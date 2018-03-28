using System;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo.DataManager
{
    public interface IDataManager<TContext>
    {
        Task ExecuteAsync(IDataCmd<TContext> cmd);

        IDataCmdFactory<TEntity, TContext> CreateCmdFactory<TEntity>() where TEntity : IDataEntity;
    }
}
