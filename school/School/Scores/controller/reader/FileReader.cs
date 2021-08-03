using System.IO;

namespace Scores.controller.reader
{
    public class FileReader : IReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}