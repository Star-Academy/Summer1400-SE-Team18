using System.Collections.Generic;

namespace Search.Database
{
    public class Data
    {
        private static readonly Data NullData = new Data("", new List<string>());
        public string Word { get; }
        public List<string> FilesWithWordInThem { get; }

        public Data(string word, List<string> filesWithWordInThem)
        {
            this.Word = word;
            this.FilesWithWordInThem = filesWithWordInThem;
        }

        public static Data GetNullData()
        {
            return NullData;
        }
    }
}