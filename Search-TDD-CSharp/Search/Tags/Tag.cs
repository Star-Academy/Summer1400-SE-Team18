namespace Search.Tags
{
    public class Tag
    {
        public string Word { get; set; }
        public TagType Type { get; set; }

        public Tag(string word, TagType type)
        {
            Word = word;
            Type = type;
        }
    }
}