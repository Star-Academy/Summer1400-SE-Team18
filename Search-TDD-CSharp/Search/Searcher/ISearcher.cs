using System.Collections.Generic;

namespace Search.Searcher
{
    public interface ISearcher
    {
        HashSet<string> Search(string command);
    }
}