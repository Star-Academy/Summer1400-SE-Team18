using System;
using System.Collections.Generic;
using System.Linq;
using Search.DatabaseAndStoring;
using Search.Models;
using Search.Tags;

namespace Search.Search
{
    public class Searcher : ISearcher
    {

        private readonly ITagCreator _tagCreator;
        private readonly IDatabase _database;

        public Searcher(ITagCreator tagCreator, IDatabase database)
        {
            _tagCreator = tagCreator;
            _database = database;
        }

        public HashSet<string> Search(string command)
        {
            var tags = _tagCreator.CreateTags(command);
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
            return _database.GetData(word);
        }
    }
}