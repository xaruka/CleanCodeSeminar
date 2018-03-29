using System.Threading.Tasks;

namespace DatabaseManager.DataManager
{
    internal interface IDataCommandExecutor<TContext>
    {
        Task Execute(TContext context);
    }
}