using System;
using DatabaseManager.DataManager;
using DatabaseManager.DataManager.Json;

namespace DatabaseManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataManager mgr = new JsonDataManager();
            var cmd = new ReadDataCommand<Person>();
            mgr.Execute(cmd).Wait();

            foreach(var person in cmd.Data)
                Console.WriteLine($"{person.Id}");

            Console.ReadKey();
        }
    }

    internal class Person
    {
        public int Id { get; set; }
    }
}
