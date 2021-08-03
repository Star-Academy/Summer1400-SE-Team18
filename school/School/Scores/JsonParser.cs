using System;
using System.IO;
using System.Text.Json;

namespace Scores
{
    public class JsonParser : IJson
    {
        public T GetObjectsArray<T>(string jsonText)
        {
            return JsonSerializer.Deserialize<T>(jsonText);
        }
    }
}