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
            var stemmer = Manager.GetInstance().Stemmer;
            var parsedText = splitText.Select(e => stemmer.Stem(e)).ToArray();

            return parsedText;
        }

        private string[] SplitWordsInText(string text)
        {
            return Regex.Split(text, SpaceRegex);
        }

        private string RemoveNonAlphabeticalWords(string text)
        {
            text = Regex.Replace(text, NonAlphabeticPattern, " ");
            return text.Trim();
        }
    }
}