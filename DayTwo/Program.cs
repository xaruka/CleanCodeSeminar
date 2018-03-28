using System;
using System.IO;
using System.Threading.Tasks;
using DayTwo.DataManager;
using DayTwo.DataManager.Json;
using DayTwo.DataManager.Sql;
using MySql.Data.MySqlClient;

namespace DayTwo
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //var db = new JsonDataManager(new FileInfo("db.json"));
            var db = new SqlDataManager(() => new MySqlConnection("host=localhost;user=root;Database=cleancode"));
            await Run(db);
            Console.ReadKey();
        }

        public static async Task Run<T>(IDataManager<T> db)
        {
            var factory = db.CreateCmdFactory<Person>();

            var insertCmd = factory.CreateInsertCommand(new Person()
            {
                Forename = "Foo",
                Surname = "Bar"
            });

            await db.ExecuteAsync(insertCmd);

            Console.WriteLine($"Created new user with Id {insertCmd.InsertKey}");

            var readCmd = factory.CreateReadCommand();

            await db.ExecuteAsync(readCmd);

            foreach (var person in readCmd.DataList)
                Console.WriteLine($"{person.EntityId} - {person.Forename} {person.Surname}");
        }

        private class Person : IDataEntity
        {
            public int EntityId { get; set; }
            public string Forename { get; set; }
            public string Surname { get; set; }
        }
    }
}
