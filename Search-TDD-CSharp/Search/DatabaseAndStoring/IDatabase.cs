using System.Collections.Generic;

namespace Search.Database
{
    public interface IDatabase
    {
        void AddData(Data data);
        Data GetData(Data data);
        HashSet<Data> GetAllData();
    }
}