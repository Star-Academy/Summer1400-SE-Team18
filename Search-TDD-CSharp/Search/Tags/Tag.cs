namespace Search.Tags
{
    public class Tag
    {
        public string Word { get; }
        public TagType Type { get; }

        public Tag(string word, TagType type)
        {
            Word = word;
            Type = type;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is not Tag comparedTag) return false;
            return this.GetHashCode() == comparedTag.GetHashCode();
        }

        public override int GetHashCode()
        {
            return (Word + Type.ToString()).GetHashCode();
        }
    }
}