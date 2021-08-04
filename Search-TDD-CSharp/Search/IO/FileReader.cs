using System.Collections.Generic;
using System.IO;

namespace Search.IO
{
    public class FileReader : IReader
    {
        public Dictionary<string, string> Read(string path)
        {
            var result = new Dictionary<string, string>();
            var text = File.ReadAllText(path);
            var filename = Path.GetFileName(path);
            result.Add(filename, text);
            return result;
        }
    }
}