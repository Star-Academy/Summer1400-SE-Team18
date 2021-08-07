using System.Collections.Generic;
using System.IO;
using System.Linq;
using Search.Dependencies;

namespace Search.IO
{
    public class FolderReader : IReader
    {

        private readonly IReader _fileReader;

        public FolderReader(IReader fileReader)
        {
            _fileReader = fileReader;
        }

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
            
            var fileContent = _fileReader.Read(fileName);
            var merged = contents.Concat(fileContent);
            return merged.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}