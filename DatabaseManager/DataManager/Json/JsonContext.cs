using System.IO;

namespace DatabaseManager.DataManager.Json
{
    internal class JsonContext
    {
        public FileInfo File { get; set; }

        public JsonContext(FileInfo file)
        {
            File = file;
        }
    }
}