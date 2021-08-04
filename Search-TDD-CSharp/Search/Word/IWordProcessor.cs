namespace Search.Word
{
    public interface IWordProcessor
    {
        string[] ParseText(string text);
        string GetStem(string word);
    }
}