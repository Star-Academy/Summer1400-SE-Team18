using System.Collections.Generic;
using Search.DatabaseAndStoring;
using Search.IO;
using Search.IO.FolderIO;
using Search.Models;
using Search.Word;

namespace Search.Index
{
    public class Indexer : IIndexer
    {

        private readonly IReader _folderReader;
        private readonly IWordProcessor _wordProcessor;
        private readonly IDatabase _database;

        public Indexer(IFolderReader folderReader, IWordProcessor wordProcessor, IDatabase database)
        {
            _folderReader = folderReader;
            _database = database;
            _wordProcessor = wordProcessor;
        }

        public void Index(string path)
        {
            var contents = _folderReader.Read(path);
            foreach (var (key, value) in contents)
            {
                AddFileTextToDatabase(value, key);
            }
        }

        private void AddFileTextToDatabase(string text, string filename)
        {
            var parsedText = _wordProcessor.ParseText(text);
            foreach (var word in parsedText)
            {
                AddFileName(word, filename);
            }
        }

        private void AddFileName(string word, string filename)
        {
            if (_database.DoesContainsWord(word)) 
                AppendFilenameToData(word, filename);
            else 
                MakeKeyInDataBase(word, filename);
        }

        private void MakeKeyInDataBase(string word, string filename)
        {
            var filenames = new HashSet<string>() {filename};
            var createdData = new Data(word, filenames);
            _database.AddModelData(createdData);
        }

        private void AppendFilenameToData(string word, string filename)
        {
            var createdData = _database.GetData(word);
            var filenames = createdData.FilesWithWordInThem;
            filenames.Add(filename);
        }
    }
}