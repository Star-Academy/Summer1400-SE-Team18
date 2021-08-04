using System.Collections.Generic;

namespace Search.DatabaseAndStoring
{
    public interface IDatabase
    {
        void AddData(Data data);
        Data GetData(string word);
        HashSet<Data> GetAllData();
        bool ContainsWord(string word);
    }
}