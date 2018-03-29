using System.Linq;
using System.Reflection;

namespace DatabaseManager.DataManager.Sql
{
    internal static class SqlQueryTypeCache<T>
    {
        public static readonly string InsertQuery;
        public static readonly string SelectQuery;

        static SqlQueryTypeCache()
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToArray();

            var tableName = $"{typeof(T).Name}s";

            InsertQuery = $"INSERT INTO {tableName} ({string.Join(",", props.Select(s => $"`{s.Name}`"))}) VALUES ({string.Join(",", props.Select(s => $"@{s.Name}"))});";
            SelectQuery = $"SELECT {string.Join(",", props.Select(s => $"`{s.Name}`"))} FROM {tableName};";
        }
    }
}
