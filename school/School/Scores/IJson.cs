using System.Collections.Generic;
using System.Text.Json;

namespace Scores
{
    public interface IJson
    {
        public T GetObjectsArray<T>(string jsonText);
    }
}