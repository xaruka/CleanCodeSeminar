using System.IO;

namespace DayTwo.DataManager.Json
{
    public class JsonFileContext
    {
        public FileInfo File { get; }

        public JsonFileContext(FileInfo file)
        {
            File = file;
        }
    }
}