using Iveonik.Stemmers;

namespace Search.Word
{
    public class Stemmer : IStemmer
    {
        private readonly EnglishStemmer _englishStemmer = new EnglishStemmer();
        public string Stem(string word)
        {
            var stemmed = _englishStemmer.Stem(word);
            return stemmed;
        }
    }
}