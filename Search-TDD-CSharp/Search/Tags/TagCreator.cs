using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Search.Dependencies;

namespace Search.Tags
{
    public class TagCreator
    {
        public HashSet<Tag> CreateTags(string command)
        {
            var words = Regex.Split(command, "\\s+");
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
            result = Manager.Stemmer.Stem(result);
            return result;
        }
        
        private TagType GetTagTypeFromWord(string word)
        {
            if (word.StartsWith("+")) return TagType.Plus;
            if (word.StartsWith("-")) return TagType.Minus; 
            return TagType.NoTag;
        }
    }
}