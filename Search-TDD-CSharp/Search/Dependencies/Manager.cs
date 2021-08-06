using Iveonik.Stemmers;
using Search.DatabaseAndStoring;
using Search.Index;
using Search.IO;
using Search.Tags;
using Search.Word;

namespace Search.Dependencies
{
    public class Manager
    {
        private static Manager Instance { get; set; }

        private Manager()
        {
        }
        
        public static Manager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Manager();
            }

            return Instance;
        }
        
        public IReader FileReaderInstance { set; get; } = new FileReader();
        public IReader FolderReaderInstance { set; get; } = new FolderReader();
        public readonly EnglishStemmer Stemmer = new EnglishStemmer();
        public readonly IWordProcessor WordProcessorInstance = new WordProcessor();
        public readonly IDatabase Database = new Database();
        public readonly IIndexer Indexer = new Indexer();
        public readonly TagCreator TagCreator = new TagCreator();

    }
}