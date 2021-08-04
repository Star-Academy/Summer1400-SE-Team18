using Iveonik.Stemmers;
using Search.DatabaseAndStoring;
using Search.Index;
using Search.IO;
using Search.Tags;
using Search.Word;

namespace Search.Dependencies
{
    public abstract class Manager
    {
        public static IReader FileReaderInstance = new FileReader();
        public static IReader FolderReaderInstance = new FolderReader();
        public static EnglishStemmer Stemmer = new EnglishStemmer();
        public static IWordProcessor WordProcessorInstance = new WordProcessor();
        public static IDatabase Database = new Database();
        public static IIndexer Indexer = new Indexer();
        public static TagCreator TagCreator = new TagCreator();

        public static void Reset()
        {
            IReader FileReaderInstance = new FileReader();
            IReader FolderReaderInstance = new FolderReader();
            EnglishStemmer Stemmer = new EnglishStemmer();
            IWordProcessor WordProcessorInstance = new WordProcessor();
            Database.GetAllData().Clear();
            IIndexer Indexer = new Indexer();
            TagCreator TagCreator = new TagCreator();
        }
    }
}