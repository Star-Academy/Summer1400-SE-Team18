using System.Linq;
using System.Text.RegularExpressions;
using Search.Dependencies;

namespace Search.Word
{
    public class WordProcessor : IWordProcessor
    {
        public string[] ParseText(string text)
        {
            text = RemoveNonAlphabeticalWords(text);
            var splitText = SplitWordsInText(text);
            var parsedText = splitText.Select(GetStem).ToArray();

            return parsedText;
        }

        public string GetStem(string word)
        {
            var lowerCaseWord = word.ToLower();
            return Manager.Stemmer.Stem(lowerCaseWord);
        }

        public string[] SplitWordsInText(string text)
        {
            return Regex.Split(text, "\\s+");
        }

        public string RemoveNonAlphabeticalWords(string text)
        { 
            text = Regex.Replace(text, "[^A-Za-z ]", " ");
            return text.Trim();
        }
    }
}