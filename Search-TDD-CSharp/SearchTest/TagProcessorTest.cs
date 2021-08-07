using System;
using System.Collections.Generic;
using System.Linq;
using Search.Dependencies;
using Search.Tags;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class TagProcessorTest
    {
        
        private readonly Manager _managerInstance = Manager.GetInstance();
        
        [Fact]
        public void Tag_ShouldProcessorCorrectly_ForAllTagTypes()
        {
            var expectedTag = new Tag("mohammad", TagType.Plus);
            var actualTag = _managerInstance.TagProcessor.Process("+mohammad");
            Action<Assert> test1 = test => Assert.Equal(expectedTag, actualTag);
            Dictionary<Tag, Tag> expectedAndActualPair = new Dictionary<Tag, Tag>()
            {
                {new Tag("mohammad", TagType.Plus), _managerInstance.TagProcessor.Process("+mohammad")},
                {new Tag("ali", TagType.Minus), _managerInstance.TagProcessor.Process("-ali")},
                {new Tag("reza", TagType.NoTag), _managerInstance.TagProcessor.Process("reza")}
            };
            Assert.All(expectedAndActualPair.ToList(),
                pair => Assert.Equal(pair.Key, pair.Value));
        }
    }
}