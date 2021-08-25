using System.Collections.Generic;
using System.IO;
using System.Linq;
using Search.IO.FileIO;

namespace Search.IO.FolderIO
{
    public class FolderReader : IFolderReader
    {

        private readonly IReader _fileReader;

        public FolderReader(IFileReader fileReader)
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

        public Dictionary<string, string> AddFileContentToDictionary(string fileName,
            IDictionary<string, string> contents)
        {
            var fileContent = _fileReader.Read(fileName);
            var merged = contents.Concat(fileContent);
            return merged.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}