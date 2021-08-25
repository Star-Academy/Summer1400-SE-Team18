using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Search.Tags
{
    public class TagCreator : ITagCreator
    {
        private const string SplitRegex = "\\s+";
        private readonly ITagProcessor _tagProcessor;

        public TagCreator(ITagProcessor tagProcessor)
        {
            _tagProcessor = tagProcessor;
        }
        
        public HashSet<Tag> CreateTags(string command)
        {
            var words = Regex.Split(command, SplitRegex);
            return CreateTagsFromArray(words);
        }
        
        private HashSet<Tag> CreateTagsFromArray(string[] words)
        {
            return words.Select(word => _tagProcessor.Process(word)).ToHashSet();
        }
    }
}