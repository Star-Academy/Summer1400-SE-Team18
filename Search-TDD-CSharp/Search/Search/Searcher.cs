using System.Collections.Generic;
using System.Linq;
using Search.DatabaseAndStoring;
using Search.Dependencies;
using Search.Tags;

namespace Search.Search
{
    public class Searcher : ISearcher
    {
        
        private readonly Manager _managerInstance = Manager.GetInstance();

        public HashSet<string> Search(string command)
        {
            var tags = _managerInstance.TagCreator.CreateTags(command);
            var result = GetNoTagWordsData(tags);
            result.UnionWith(GetPlusTagWordsData(tags));
            result.RemoveWhere(fileName => GetMinusTagWordsData(tags).Contains(fileName));
            
            return result;
        }

        private HashSet<string> GetNoTagWordsData(HashSet<Tag> tags)
        {
            var allNoTagWords = tags.Where(tag => tag.Type == TagType.NoTag);
            if (!allNoTagWords.Any()) return new HashSet<string>();
            var allAnswers = allNoTagWords.Select(tag => GetDataForWord(tag.Word).FilesWithWordInThem);
            return allAnswers.Aggregate((current, next) => current.Intersect(next).ToHashSet())
                .ToHashSet();
        }

        private HashSet<string> GetPlusTagWordsData(HashSet<Tag> tags) 
            => tags.Where(tag => tag.Type == TagType.Plus)
            .SelectMany(tag => GetDataForWord(tag.Word).FilesWithWordInThem).ToHashSet();
        
        private HashSet<string> GetMinusTagWordsData(HashSet<Tag> tags) 
            => tags.Where(tag => tag.Type == TagType.Minus)
            .SelectMany(tag => GetDataForWord(tag.Word).FilesWithWordInThem).ToHashSet();

        private Data GetDataForWord(string word)
        {
            return _managerInstance.Database.GetData(word);
        }
    }
}