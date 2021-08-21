using System.Collections.Generic;
using Search.Models;

namespace Search.DatabaseAndStoring
{
    public interface IDatabase
    {
        void AddModelData(Data data);
        Data GetData(string word);
        bool DoesContainsWord(string word);
    }
}