using System;
using System.Collections.Generic;
using System.Linq;
using Search.Models;

namespace Search.DatabaseAndStoring
{
    public class Database : IDatabase
    {
        private readonly DatabaseContext _databaseContext;

        public Database(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public void AddModelData(DataEntity data)
        {
            Console.WriteLine(data.Word + " " + data.FileName);
            _databaseContext.Add(data);
            _databaseContext.SaveChanges();
        }

        public Data GetData(string word)
        {
            var fileNames = new HashSet<string>();
            var query = _databaseContext.DataEntities;
            foreach (var dataEntity in query)
            {
                if (word == dataEntity.Word) fileNames.Add(dataEntity.FileName);
            }

            return new Data(word, fileNames);
        }

        public bool DoesContainsWord(string word)
        {
            return GetData(word).HasFilesWithWordInThem();
        }
    }
}