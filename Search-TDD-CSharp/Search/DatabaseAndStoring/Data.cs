using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Search.DatabaseAndStoring
{
    public class Data
    {
        [Key]
        public string Word { get; set; }

        [Required]
        public HashSet<string> FilesWithWordInThem { get; }

        public Data()
        {
            Word = "";
            FilesWithWordInThem = new HashSet<string>();
        }

        public Data(string word, HashSet<string> filesWithWordInThem)
        {
            Word = word;
            FilesWithWordInThem = filesWithWordInThem;
        }

        public bool HasFilesWithWordInThem()
        {
            return FilesWithWordInThem.Count != 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not Data comparedData) return false;
            return comparedData.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Word.GetHashCode();
        }
    }
}