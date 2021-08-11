using System.Text.Json;

namespace Scores.Controller.Parser
{
    public class JsonParser : IJson
    {
        public T GetObjectsArray<T>(string jsonText)
        {
            return JsonSerializer.Deserialize<T>(jsonText);
        }
    }
}