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
        public static readonly EnglishStemmer Stemmer = new EnglishStemmer();
        public static readonly IWordProcessor WordProcessorInstance = new WordProcessor();
        public static readonly IDatabase Database = new Database();
        public static readonly IIndexer Indexer = new Indexer();
        public static readonly TagCreator TagCreator = new TagCreator();

        public static void Reset()
        {
            Database.GetAllData().Clear();
        }
    }
}