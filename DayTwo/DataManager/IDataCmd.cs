using System.Threading.Tasks;

namespace DayTwo.DataManager
{
    public interface IDataCmd<in TContext>
    {
        Task ExecuteAsync(TContext context);
    }
}