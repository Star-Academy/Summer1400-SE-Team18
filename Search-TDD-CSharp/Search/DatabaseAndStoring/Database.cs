using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Search.DatabaseAndStoring
{
    public class Database : IDatabase
    {
        private HashSet<Data> _data;

        public Database()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            var databaseString = File.ReadAllText("database.json");
            var database = JsonSerializer.Deserialize<HashSet<DataHelper>>(databaseString);
            _data = ConvertDataHelpersToData(database);
        }

        private HashSet<Data> ConvertDataHelpersToData(HashSet<DataHelper> dataHelpers)
        {
            var result = new HashSet<Data>();
            foreach (var dataHelper in dataHelpers)
            {
                result.Add(DataHelperToData(dataHelper));
            }
            return result;
        }

        private Data DataHelperToData(DataHelper dataHelper)
        {
            var result = new Data(dataHelper.Word, new HashSet<string>());
            foreach (var s in dataHelper.FilesWithWordInThem)
            {
                result.FilesWithWordInThem.Add(s);
            }

            return result;
        }

        public void AddModelData(Data data)
        {
            ChangeDataContentToLowerCase(data);
            _data.Add(data);
        }

        private void ChangeDataContentToLowerCase(Data data)
        {
            data.Word = data.Word.ToLower();
        }

        public Data GetData(string word)
        {
            var fileNames = new HashSet<string>();
            foreach (var dataEntity in _data)
            {
                if (word == dataEntity.Word) return dataEntity;
            }

            return new Data(word, fileNames);
        }

        public bool DoesContainsWord(string word)
        {
            return GetData(word).HasFilesWithWordInThem();
        }

        public HashSet<Data> GetAllData()
        {
            return _data;
        }
    }

    public class DataHelper
    {
        public string Word { get; set; }
        public List<string> FilesWithWordInThem { get; set; }
    }
}