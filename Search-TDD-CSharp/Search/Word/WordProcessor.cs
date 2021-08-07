using System.Linq;
using System.Text.RegularExpressions;
using Search.Dependencies;

namespace Search.Word
{
    public class WordProcessor : IWordProcessor
    {
        private readonly Manager _managerInstance = Manager.GetInstance();
        private const string NonAlphabeticPattern = "[^A-Za-z ]";
        private const string SpaceRegex = "\\s+";

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
            return _managerInstance.Stemmer.Stem(lowerCaseWord);
        }

        public string[] SplitWordsInText(string text)
        {
            return Regex.Split(text, SpaceRegex);
        }

        public string RemoveNonAlphabeticalWords(string text)
        {
            text = Regex.Replace(text, NonAlphabeticPattern, " ");
            return text.Trim();
        }
    }
}