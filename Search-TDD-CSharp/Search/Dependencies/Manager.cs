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
        
        public IReader FileReaderInstance { set; get; }
        public IReader FolderReaderInstance { set; get; }
        public ICustomStemmer Stemmer; 
        public IWordProcessor WordProcessorInstance; 
        public IDatabase Database; 
        public IIndexer Indexer; 
        public ITagCreator TagCreator;
        public ITagProcessor TagProcessor;

    }
}