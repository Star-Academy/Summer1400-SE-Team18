using System.Collections.Generic;

namespace Search.DatabaseAndStoring
{
    public interface IDatabase
    {
        void AddData(Data data);
        Data GetData(string word);
        bool ContainsWord(string word);
        bool DoesContainsWord(string word);
    }
}