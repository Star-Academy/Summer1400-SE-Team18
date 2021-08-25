using Search.Word;

namespace Search.Tags
{
    public class TagProcessor : ITagProcessor
    {
        private const string MinusSign = "-";
        private const string PlusSign = "+";

        public Tag Process(string word)
        {
            var wordTagType = GetTagTypeFromWord(word);
            var cleanWord = CleanWord(word);
            return new Tag(cleanWord, wordTagType);
        }

        private string CleanWord(string word)
        {
            var result = word.ToLower();
            if (!IsNoTag(word))
            {
                result = result[1..];
            }

            return result;
        }

        private TagType GetTagTypeFromWord(string word)
        {
            if (word.StartsWith(PlusSign)) return TagType.Plus;
            else if (word.StartsWith(MinusSign)) return TagType.Minus;
            return TagType.NoTag;
        }

        private bool IsNoTag(string word)
        {
            return !(word.StartsWith(PlusSign) || word.StartsWith(MinusSign));
        }
        
    }
}