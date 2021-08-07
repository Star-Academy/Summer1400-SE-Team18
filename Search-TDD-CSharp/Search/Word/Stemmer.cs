using Iveonik.Stemmers;

namespace Search.Word
{
    public class Stemmer : ICustomStemmer
    {
        private readonly IStemmer _englishStemmer;

        public Stemmer(IStemmer englishStemmer)
        {
            _englishStemmer = englishStemmer;
        }
        public string Stem(string word)
        {
            var stemmed = _englishStemmer.Stem(word);
            return stemmed;
        }
    }
}