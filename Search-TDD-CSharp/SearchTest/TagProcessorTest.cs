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
        
        [Theory]
        [InlineData("+mohammad", TagType.Plus)]
        [InlineData("-ali", TagType.Minus)]
        [InlineData("reza", TagType.NoTag)]
        public void Tag_ShouldProcessorCorrectly_ForAllTagTypes(string word, TagType tagType)
        {
            var expectedAndActualPair = new Dictionary<Tag, Tag>()
            {
                {new Tag("mohammad", TagType.Plus), _managerInstance.TagProcessor.Process("+mohammad")},
                {new Tag("ali", TagType.Minus), _managerInstance.TagProcessor.Process("-ali")},
                {new Tag("reza", TagType.NoTag), _managerInstance.TagProcessor.Process("reza")}
            };
            var tagProcessor = _managerInstance.TagProcessor;
            var tagged = tagProcessor.Process(word);
            Assert.Equal(tagged.Type, tagType);
        }
    }
}