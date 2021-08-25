using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Search.Word
{
    public class WordProcessor : IWordProcessor
    {
        private const string NonAlphabeticPattern = "[^A-Za-z ]";
        private const string WhiteSpace = " ";
        private const string SpaceRegex = "\\s+";
        
        public List<string> ParseText(string text)
        {
            text = RemoveNonAlphabeticalWords(text);
            var splitText = SplitWordsInText(text);

            return splitText;
        }

        private List<string> SplitWordsInText(string text)
        {
            return Regex.Split(text, SpaceRegex).ToList();
        }

        private string RemoveNonAlphabeticalWords(string text)
        {
            text = Regex.Replace(text, NonAlphabeticPattern, WhiteSpace);
            return text.Trim();
        }
    }
}