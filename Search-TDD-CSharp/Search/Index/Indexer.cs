using System.Collections.Generic;
using Search.DatabaseAndStoring;
using Search.Dependencies;

namespace Search.Index
{
    public class Indexer : IIndexer
    {
        public void Index(string path)
        {
            var contents = Manager.FolderReaderInstance.Read(path);
            var database = Manager.Database;
            foreach (var (key, value) in contents)
            {
                AddFileTextToDatabase(value, key, database);
            }
        }

        private void AddFileTextToDatabase(string text, string filename, IDatabase database)
        {
            var parsedText = Manager.WordProcessorInstance.ParseText(text);
            foreach (var word in parsedText)
            {
                if (database.ContainsWord(word)) AppendFilenameToData(word, filename, database);
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