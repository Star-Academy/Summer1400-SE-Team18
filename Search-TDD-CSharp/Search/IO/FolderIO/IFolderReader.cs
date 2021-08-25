using System.Collections.Generic;

namespace Search.IO.FolderIO
{
    public interface IFolderReader : IReader
    {
        Dictionary<string, string> AddFileContentToDictionary(string fileName, IDictionary<string, string> contents);
    }
}