using System.Collections.Generic;

namespace Search.DatabaseAndStoring
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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not Data comparedData) return false;
            return comparedData.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            string filenames = "";
            foreach (var s in FilesWithWordInThem)
            {
                filenames += s;
            }

            return (Word + filenames).GetHashCode();
        }
    }
}