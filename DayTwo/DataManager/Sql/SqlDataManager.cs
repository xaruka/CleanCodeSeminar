using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo.DataManager.Sql
{
    public class SqlDataManager : IDataManager<SqlContext>
    {
        public delegate IDbConnection ConnectionFactoryDelegate();

        private readonly ConnectionFactoryDelegate createDbConnection;

        public SqlDataManager(ConnectionFactoryDelegate createDbConnection)
        {
            this.createDbConnection = createDbConnection;
        }

        public async Task ExecuteAsync(IDataCmd<SqlContext> cmd)
        {
            await cmd.ExecuteAsync(new SqlContext(createDbConnection()));
        }

        public IDataCmdFactory<TEntity, SqlContext> CreateCmdFactory<TEntity>() where TEntity : class, IDataEntity
        {
            return new SqlCmdFactory<TEntity>();
        }
    }
}
