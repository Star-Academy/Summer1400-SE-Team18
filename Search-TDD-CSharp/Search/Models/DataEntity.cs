using System;

namespace Search.Models
{
    public class DataEntity
    {
        public string Word { get; set; }
        public string FileName { get; set; }

        public DataEntity()
        {
            Word = "";
            FileName = "";
        }

        public DataEntity(string word, string fileName)
        {
            Word = word;
            FileName = fileName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is DataEntity secondObj)
            {
                return this.Word.Equals(secondObj.Word) && this.FileName.Equals(secondObj.FileName);
            }

            return false;
        }
    }
}