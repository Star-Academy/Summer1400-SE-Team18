using System.Collections.Generic;

namespace Search.Tags
{
    public interface ITagCreator
    {
        HashSet<Tag> CreateTags(string command);
    }
}