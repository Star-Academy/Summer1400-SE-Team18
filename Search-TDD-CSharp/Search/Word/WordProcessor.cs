using System.Linq;
using System.Text.RegularExpressions;

namespace Search.Word
{
    public class WordProcessor : IWordProcessor
    {
        private const string NonAlphabeticPattern = "[^A-Za-z ]";
        private const string WhiteSpace = " ";
        private const string SpaceRegex = "\\s+";
        private readonly ICustomStemmer _stemmer;

        public WordProcessor(ICustomStemmer stemmer)
        {
            _stemmer = stemmer;
        }

        public string[] ParseText(string text)
        {
            text = RemoveNonAlphabeticalWords(text);
            var splitText = SplitWordsInText(text);
            var parsedText = splitText.Select(e => _stemmer.Stem(e)).ToArray();

            return parsedText;
        }

        private string[] SplitWordsInText(string text)
        {
            return Regex.Split(text, SpaceRegex);
        }

        private string RemoveNonAlphabeticalWords(string text)
        {
            text = Regex.Replace(text, NonAlphabeticPattern, WhiteSpace);
            return text.Trim();
        }
    }
}