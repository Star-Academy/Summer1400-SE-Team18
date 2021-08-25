using System.Collections.Generic;

namespace Search.IO
{
    public interface IReader
    {
        Dictionary<string, string> Read(string path);
    }
}