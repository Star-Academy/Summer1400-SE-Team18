using System.Collections.Generic;
using System.Linq;
using Search.DatabaseAndStoring;
using Search.Dependencies;
using Search.Tags;

namespace Search.Search
{
    public class Searcher : ISearcher
    {
        public HashSet<string> Search(string command)
        {
            var tags = Manager.TagCreator.CreateTags(command);
            var result = tags.Where(tag => tag.Type == TagType.NoTag)
                .Select(tag => GetDataForWord(tag.Word).FilesWithWordInThem)
                .Aggregate((current, next) => current.Intersect(next).ToHashSet()).ToHashSet();
            result.UnionWith(tags.Where(tag => tag.Type == TagType.Plus)
                .Select(tag => GetDataForWord(tag.Word).FilesWithWordInThem).Aggregate((current, next) =>
                {
                    current.UnionWith(next);
                    return current;
                }).ToHashSet());
            result.RemoveWhere((tag) => tags.Where(tag => tag.Type == TagType.Minus)
                .Select(tag => GetDataForWord(tag.Word).FilesWithWordInThem).Aggregate((current, next) =>
                {
                    current.UnionWith(next);
                    return current;
                }).ToHashSet().Contains(tag));
            return result;
        }

        private static Data GetDataForWord(string word)
        {
            return Manager.Database.GetData(word);
        }
    }
}