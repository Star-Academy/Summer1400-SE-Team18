using Iveonik.Stemmers;
using Search.IO;
using Search.Word;

namespace Search.Dependencies
{
    public class Manager
    {
        public static IReader FileReaderInstance = new FileReader();
        public static IReader FolderReaderInstance = new FolderReader();
        public static EnglishStemmer Stemmer = new EnglishStemmer();
        public static IWordProcessor WordProcessorInstance = new WordProcessor();

    }
}