using System.Collections.Generic;

namespace Search.Word
{
    public interface IWordProcessor
    {
        List<string> ParseText(string text);
    }
}