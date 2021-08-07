using System.Collections.Generic;
using System.IO.Enumeration;
﻿using System.Collections.Generic;
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
            foreach (var (key, value) in contents)
            {
                AddFileTextToDatabase(value, key);
            }
        }

        private void AddFileTextToDatabase(string text, string filename)
        {
            var database = _managerInstance.Database;
            var parsedText = _managerInstance.WordProcessorInstance.ParseText(text);
            foreach (var word in parsedText)
            {
                ChooseToMakeOrAppend(word, filename);
            }
        }

        private void ChooseToMakeOrAppend(string word, string filename)
        {
            var database = _managerInstance.Database;
            if (database.DoesContainsWord(word)) 
                AppendFilenameToData(word, filename);
            else 
                MakeKeyInDataBase(word, filename);
        }

        private void MakeKeyInDataBase(string word, string filename)
        {
            var database = _managerInstance.Database;
            var filenames = new HashSet<string>(new[]{filename});
            var createdData = new Data(word, filenames);
            database.AddData(createdData);
        }

        private void AppendFilenameToData(string word, string filename)
        {
            var database = _managerInstance.Database;
            var createdData = database.GetData(word);
            var filenames = createdData.FilesWithWordInThem;
            filenames.Add(filename);
        }
    }
}