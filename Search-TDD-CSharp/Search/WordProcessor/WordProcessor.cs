using System.Text.RegularExpressions;
using Search.Dependencies;
using System.Linq;

namespace Search.WordProcessor
{
    public class WordProcessor : IWordProcessor
    {
        public string[] ParseText(string text)
        {
            text = RemoveNonAlphabeticalWords(text);
            var parsedText = SplitWordsInText(text);
            var result = parsedText.Select(GetStem);

            return parsedText;
        }

        public string GetStem(string word)
        {
            return Manager.Stemmer.Stem(word);
        }

        public string[] SplitWordsInText(string text)
        {
            return Regex.Split(text, "\\s+");
        }

        public string RemoveNonAlphabeticalWords(string text)
        {
            return Regex.Replace(text, "[^A-Za-z ]", "");
        }
    }
}