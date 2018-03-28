using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DayTwo.DataManager.Sql
{
    internal static class SqlQueryTypeCache<T> where T: IDataEntity
    {
        public static readonly string InsertQuery;
        public static readonly string SelectQuery;

        static SqlQueryTypeCache()
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.DeclaringType != typeof(IDataEntity)).ToArray();

            var tableName = $"{typeof(T).Name}s";

            InsertQuery = $"INSERT INTO {tableName} ({string.Join(",", props.Select(s => $"`{s.Name}`"))}) VALUES ({string.Join(",", props.Select(s => $"@{s.Name}"))});";
            SelectQuery = $"SELECT {string.Join(",", props.Select(s => $"`{s.Name}`"))} FROM {tableName};";
        }
    }
}
