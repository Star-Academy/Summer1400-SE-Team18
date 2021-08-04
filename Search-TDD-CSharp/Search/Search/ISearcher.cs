using System.Collections.Generic;

namespace Search.Search
{
    public interface ISearcher
    {
        HashSet<string> Search(string command);
    }
}