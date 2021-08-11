namespace Scores.Controller.Parser
{
    public interface IJson
    {
        public T GetObjectsArray<T>(string jsonText);
    }
}