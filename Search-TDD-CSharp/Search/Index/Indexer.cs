using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using Search.DatabaseAndStoring;
using Search.Dependencies;

namespace Search.Index
{
    public class Indexer : IIndexer
    {
        
        private readonly Manager _managerInstance = Manager.GetInstance();

        public void Index(string path)
        {
            var contents = _managerInstance.FolderReaderInstance.Read(path);
            var database = _managerInstance.Database;
            foreach (var (key, value) in contents)
            {
                AddFileTextToDatabase(value, key, database);
            }
        }

        private void AddFileTextToDatabase(string text, string filename, IDatabase database)
        {
            var parsedText = _managerInstance.WordProcessorInstance.ParseText(text);
            foreach (var word in parsedText)
            {
                ChooseToMakeOrAppend(word, filename, database);
            }
        }

        private void ChooseToMakeOrAppend(string word, string filename, IDatabase database)
        {
            if (database.DoesContainsWord(word)) 
                AppendFilenameToData(word, filename, database);
            else 
                MakeKeyInDataBase(word, filename, database);
        }

        private void MakeKeyInDataBase(string word, string filename, IDatabase database)
        {
            var filenames = new HashSet<string>(new[]{filename});
            var createdData = new Data(word, filenames);
            database.AddData(createdData);
        }

        private void AppendFilenameToData(string word, string filename, IDatabase database)
        {
            var createdData = database.GetData(word);
            var filenames = createdData.FilesWithWordInThem;
            filenames.Add(filename);
        }
    }
}