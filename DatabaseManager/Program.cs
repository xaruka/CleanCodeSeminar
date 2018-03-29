using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DatabaseManager.DataManager;
using DatabaseManager.DataManager.Json;
using DatabaseManager.DataManager.Sql;
using MySql.Data.MySqlClient;

namespace DatabaseManager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //AnotherMain(new JsonDataManager(new FileInfo("db.json"))).Wait();
            AnotherMain(new SqlDataManager(() => new MySqlConnection("host=localhost;user=root;Database=cleancode"))).Wait();

            Console.ReadKey();
        }

        private static async Task AnotherMain(IDataManager mgr)
        {
            var insertCmd = new InsertDataCommand<Person>(new Person
            {
                Forename = "Foo",
                Surname = "Bar"
            });
            await mgr.Execute(insertCmd);

            var cmd = new ReadDataCommand<Person>();
            await mgr.Execute(cmd);

            foreach (var person in cmd.Data)
                Console.WriteLine($"{person.Forename} {person.Surname}");
        }
    }

    internal class Person
    {
        public int EntityId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
}
