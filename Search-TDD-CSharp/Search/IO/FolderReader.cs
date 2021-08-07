using System.Collections.Generic;
using System.IO;
using System.Linq;
using Search.Dependencies;

namespace Search.IO
{
    public class FolderReader : IReader
    {
        
        private readonly Manager _managerInstance = Manager.GetInstance();

        public Dictionary<string, string> Read(string path)
        {
            var result = new Dictionary<string, string>();
            foreach (var file in Directory.GetFiles(path))
            {
                result = AddFileContentToDictionary(file, result);
            }

            return result;
        }

        private Dictionary<string, string> AddFileContentToDictionary(string fileName,
            IDictionary<string, string> contents)
        {
            var fileReader = _managerInstance.FileReaderInstance;
            var fileContent = fileReader.Read(fileName);
            var merged = contents.Concat(fileContent);
            return merged.ToDictionary(e => e.Key, e => e.Value);
        }
    }
}