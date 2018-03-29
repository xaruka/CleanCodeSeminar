using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.DataManager.Sql
{
    class SqlDataManager : IDataManager
    {
        public delegate IDbConnection ConnectionFactoryDelegate();

        private readonly ConnectionFactoryDelegate createDbConnection;

        public SqlDataManager(ConnectionFactoryDelegate createDbConnection)
        {
            this.createDbConnection = createDbConnection;
        }

        public async Task Execute<TEntity>(IDataCommand<TEntity> cmd)
        {
            var executor = cmd.MapToDataCommandExecutor(new SqlDataCommandExecutorFactory<TEntity>());
            await executor.Execute(new SqlContext(createDbConnection()));
        }
    }
}
