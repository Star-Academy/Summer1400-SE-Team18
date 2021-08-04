using Iveonik.Stemmers;
using Search.DatabaseAndStoring;
using Search.Index;
using Search.IO;
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
    }
}