using System.Collections.Generic;
using System.Linq;

namespace Search.DatabaseAndStoring
{
    public class Database : IDatabase
    {
        private readonly HashSet<Data> _datas = new HashSet<Data>();

        public void AddData(Data data)
        {
            _datas.Add(data);
        }

        public Data GetData(string word)
        {
            foreach (var data in _datas.Where(data => data.Word == word))
            {
                return data;
            }

            return Data.GetNullData();
        }

        public HashSet<Data> GetAllData()
        {
            return _datas;
        }

        public bool ContainsWord(string word)
        {
            return GetData(word).FilesWithWordInThem.Count != 0;
        }
    }
}