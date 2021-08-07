using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Search.Dependencies;

namespace Search.Tags
{
    public class TagCreator : ITagCreator
    {
        
        private readonly Manager _managerInstance = Manager.GetInstance();
        private const string SplitRegex = "\\s+";
        private const string MinusSign = "+";
        private const string PlusSign = "-";

        public HashSet<Tag> CreateTags(string command)
        {
            var words = Regex.Split(command, SplitRegex);
            return CreateTagsFromArray(words);
        }

        private HashSet<Tag> CreateTagsFromArray(string[] words) 
            => words.Select(word => new Tag(CleaningWord(word), GetTagTypeFromWord(word))).ToHashSet();

        private string CleaningWord(string word)
        {
            string result = word.ToLower();
            if (word.StartsWith("+") || word.StartsWith("-"))
            {
                result = result[1..];
            }
            result = _managerInstance.Stemmer.Stem(result);
            return result;
        }
        
        private TagType GetTagTypeFromWord(string word)
        {
            if (word.StartsWith(PlusSign)) return TagType.Plus;
            else if (word.StartsWith(MinusSign)) return TagType.Minus; 
            return TagType.NoTag;
        }
    }
}