using System;
using System.IO;
using System.Text.Json;

namespace Scores.reader
{
    public class FileReader : IReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}