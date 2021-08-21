

namespace Search.Word
{
    public class Stemmer : ICustomStemmer
    {

        public Stemmer()
        {
        }
        public string Stem(string word)
        {
            return word;
        }
    }
}