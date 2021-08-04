using System;
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
            var result = GetNoTagWordsData(tags);
            result.UnionWith(GetPlusTagWordsData(tags));
            result.RemoveWhere(fileName => GetMinusTagWordsData(tags).Contains(fileName));
            
            return result;
        }

        private HashSet<string> GetNoTagWordsData(HashSet<Tag> tags)
        {
            try
            {
                return tags.Where(tag => tag.Type == TagType.NoTag)
                    .Select(tag => GetDataForWord(tag.Word).FilesWithWordInThem)
                    .Aggregate((current, next) => current.Intersect(next).ToHashSet())
                    .ToHashSet();
            } 
            catch (Exception)
            {
                return new HashSet<string>();
            }
        }

        private HashSet<string> GetPlusTagWordsData(HashSet<Tag> tags) 
            => tags.Where(tag => tag.Type == TagType.Plus)
            .SelectMany(tag => GetDataForWord(tag.Word).FilesWithWordInThem).ToHashSet();
        
        private HashSet<string> GetMinusTagWordsData(HashSet<Tag> tags) 
            => tags.Where(tag => tag.Type == TagType.Minus)
            .SelectMany(tag => GetDataForWord(tag.Word).FilesWithWordInThem).ToHashSet();

        private static Data GetDataForWord(string word)
        {
            return Manager.Database.GetData(word);
        }
    }
}