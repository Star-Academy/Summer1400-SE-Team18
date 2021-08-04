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
            HashSet<string> result = new HashSet<string>();
            //No Tag
            try
            {
                result = tags.Where(tag => tag.Type == TagType.NoTag)
                    .Select(tag => GetDataForWord(tag.Word).FilesWithWordInThem)
                    .Aggregate((current, next) => current.Intersect(next).ToHashSet()).ToHashSet();
            }
            catch (Exception ignored)
            {
                // ignored
            }

            //Plus Tag
            try
            {
                var query = tags.Where(tag => tag.Type == TagType.Plus)
                    .SelectMany(tag => GetDataForWord(tag.Word).FilesWithWordInThem).ToHashSet();
                result.UnionWith(query);
            }
            catch (Exception ignored)
            {
                // ignored
            }

            //Minus Tag
            try
            {
                var query = tags.Where(tag => tag.Type == TagType.Minus)
                    .SelectMany(tag => GetDataForWord(tag.Word).FilesWithWordInThem).ToHashSet();
                result.RemoveWhere(tag => query.Contains(tag));
            } 
            catch (Exception ignored)
            {
                // ignored
            }
                
            return result;
        }

        private static Data GetDataForWord(string word)
        {
            return Manager.Database.GetData(word);
        }
    }
}