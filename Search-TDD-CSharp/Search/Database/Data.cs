using System.Collections.Generic;

namespace Search.Database
{
    public class Data
    {
        public string Word { get; }
        public List<string> FilesWithWordInThem { get; }

        public Data(string word, List<string> filesWithWordInThem)
        {
            this.Word = word;
            this.FilesWithWordInThem = filesWithWordInThem;
        }
    }
}