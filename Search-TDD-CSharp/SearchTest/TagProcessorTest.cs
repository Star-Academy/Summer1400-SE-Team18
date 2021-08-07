using System;
using System.Collections.Generic;
using System.Linq;

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
        public void Tag_ShouldProcessTagTypesCorrectly_ForAllTagTypes(string command, TagType tagType)
        {
            var tagProcessor = _managerInstance.TagProcessor;
            var tagged = tagProcessor.Process(command);
            Assert.Equal(tagged.Type, tagType);
        }

        [Theory]
        [InlineData("+mohammad", "mohammad")]
        [InlineData("-ali", "ali")]
        [InlineData("reza", "reza")]
        public void Tag_ShouldProcessWordsCorrectly_ForAllTagTypes(string command, string word)
        {
            var tagProcessor = _managerInstance.TagProcessor;
            var tagged = tagProcessor.Process(command);
            Assert.Equal(tagged.Word, word);
        }
    }
}