using Search.DatabaseAndStoring;
using Search.Index;
using Search.IO;
using Search.Tags;
using Search.Word;
using IStemmer = Search.Word.IStemmer;

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
                Instance.Initialize();
            }

            return Instance;
        }
        
        public IReader FileReaderInstance { set; get; }
        public IReader FolderReaderInstance { set; get; }
        public IStemmer Stemmer; 
        public IWordProcessor WordProcessorInstance; 
        public Database Database; 
        public IIndexer Indexer; 
        public ITagCreator TagCreator; 

        private void Initialize()
        {
            FileReaderInstance = new FileReader();
            FolderReaderInstance = new FolderReader();
            Stemmer = new Stemmer();
            WordProcessorInstance = new WordProcessor();
            Database = new Database();
            Indexer = new Indexer();
            TagCreator = new TagCreator();
        }

    }
}