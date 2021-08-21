using System;
using System.Collections.Generic;
using System.IO;

namespace Search.IO.FileIO
{
    public class FileReader : IFileReader
    {
        public Dictionary<string, string> Read(string path)
        {
            var text = File.ReadAllText(path);
            var filename = Path.GetFileName(path);
            var result = new Dictionary<string, string> {{filename, text}};
            return result;
        }
    }
}