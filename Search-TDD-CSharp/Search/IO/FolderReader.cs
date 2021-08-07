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
            var fileReader = _managerInstance.FileReaderInstance;
            foreach (var file in Directory.GetFiles(path))
            {
                AddFileContentToDictionary(file, result, fileReader);
            }

            return result;
        }

        private static void AddFileContentToDictionary(string fileName,
            IDictionary<string, string> contents,
            IReader fileReader)
        {
            var fileContent = fileReader.Read(fileName);
            fileContent.All(pair =>
            {
                contents.Add(pair);
                return true;
            });
        }
    }
}