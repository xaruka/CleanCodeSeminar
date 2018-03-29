using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public static class FileExtensions
    {
        public static async Task<string> ReadAllTextAsync(this FileInfo file)
        {
            file.Refresh();
            if (!file.Exists)
                return "";

            var builder = new StringBuilder();
            var buffer = new byte[8 * 1024];
            using (var stream = file.OpenRead())
            {
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                builder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            return builder.ToString();
        }
        public static async Task WriteAllTextAsync(this FileInfo file, string text)
        {
            file.Refresh();
            using (var stream = file.OpenWrite())
            {
                var buffer = Encoding.UTF8.GetBytes(text);
                await stream.WriteAsync(buffer, 0, buffer.Length);
                await stream.FlushAsync();
            }
        }
    }
}
