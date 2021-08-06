using System;
using System.Collections.Generic;
using System.Linq;

namespace Search.DatabaseAndStoring
{
    public class Database : IDatabase
    {
        private readonly HashSet<Data> _data = new HashSet<Data>();

        public void AddData(Data data)
        {
            _data.Add(data);
        }

        public Data GetData(string word)
        {
            try
            {
                return _data.First(data => data.Word == word);
            }
            catch
            {
                return Data.NullData;
            }
        }

        public void ClearAll() => _data.Clear();

        public bool ContainsWord(string word)
        {
            return GetData(word).HasFilesWithWordInThem();
        }
    }
}