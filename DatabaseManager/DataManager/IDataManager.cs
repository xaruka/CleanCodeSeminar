using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.DataManager
{
    internal interface IDataManager
    {
        Task Execute<TEntity>(IDataCommand<TEntity> cmd);
    }
}
