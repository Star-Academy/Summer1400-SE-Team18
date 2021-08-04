using System.Collections.Generic;

namespace Search.Database
{
    public class Data
    {
        private static readonly Data NullData = new Data("", new HashSet<string>());
        public string Word { get; }
        public HashSet<string> FilesWithWordInThem { get; }

        public Data(string word, HashSet<string> filesWithWordInThem)
        {
            Word = word;
            FilesWithWordInThem = filesWithWordInThem;
        }

        public static Data GetNullData()
        {
            return NullData;
        }
    }
}