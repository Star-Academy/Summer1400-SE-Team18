namespace Search.Models
{
    public class DataEntity
    {
        public string Word { get; }
        public string FileName { get; }

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
    }
}