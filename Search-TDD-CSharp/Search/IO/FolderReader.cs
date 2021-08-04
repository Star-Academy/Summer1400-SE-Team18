using System.Collections.Generic;
using System.IO;
using Search.Dependencies;

namespace Search.IO
{
    public class FolderReader : IReader
    {
        public Dictionary<string, string> Read(string path)
        {
            var result = new Dictionary<string, string>();
            var fileReader = Manager.FileReaderInstance;
            foreach (var file in Directory.GetFiles(path))
            {
                var fileContent = fileReader.Read(file);
                AddFileContentToDictionary(fileContent, result);
            }

            return result;
        }

        private static void AddFileContentToDictionary(Dictionary<string, string> fileContent,
            IDictionary<string, string> contents)
        {
            foreach (var (key, value) in fileContent)
            {
                contents.Add(key, value);
            }
        }
    }
}