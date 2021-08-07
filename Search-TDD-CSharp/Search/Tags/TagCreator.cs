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
        
        public HashSet<Tag> CreateTags(string command)
        {
            var words = Regex.Split(command, SplitRegex);
            return CreateTagsFromArray(words);
        }
        
        private HashSet<Tag> CreateTagsFromArray(string[] words)
        {
            var tagProcessor = _managerInstance.TagProcessor;
            return words.Select(word => tagProcessor.Process(word)).ToHashSet();
        }
    }
}