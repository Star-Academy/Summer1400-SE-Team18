using System.IO;

namespace Scores.Controller.Reader
{
    public class FileReader : IReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}