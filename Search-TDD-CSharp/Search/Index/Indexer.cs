using System;
using System.Collections.Generic;
using Search.DatabaseAndStoring;
using Search.Dependencies;

namespace Search.Index
{
    public class Indexer : IIndexer
    {
        
        private readonly Manager _managerInstance = Manager.GetInstance();

        public void Index(string path)
        {
            if (_managerInstance == null) throw new NotImplementedException();
            if (_managerInstance.FolderReaderInstance == null) throw new AggregateException();
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
                if (database.DoesContainsWord(word)) AppendFilenameToData(word, filename, database);
                else MakeKeyInDataBase(word, filename, database);
            }
        }

        private void MakeKeyInDataBase(string word, string filename, IDatabase database)
        {
            HashSet<string> filenames = new HashSet<string>(new[]{filename});
            Data createdData = new Data(word, filenames);
            database.AddData(createdData);
        }

        private void AppendFilenameToData(string word, string filename, IDatabase database)
        {
            Data alreadyCreatedData = database.GetData(word);
            HashSet<string> filenames = alreadyCreatedData.FilesWithWordInThem;
            filenames.Add(filename);
        }
    }
}