using NSubstitute;
using Search.Tags;
using Search.Word;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class TagProcessorTest
    {

        private readonly ITagProcessor _tagProcessor;
        
        public TagProcessorTest()
        {
            _tagProcessor = new TagProcessor();
        }
        
        [Theory]
        [InlineData("+mohammad", TagType.Plus)]
        [InlineData("-ali", TagType.Minus)]
        [InlineData("reza", TagType.NoTag)]
        public void Tag_ShouldProcessTagTypesCorrectly_ForAllTagTypes(string command, TagType tagType)
        {
            var tagged = _tagProcessor.Process(command);
            Assert.Equal(tagged.Type, tagType);
        }

        [Theory]
        [InlineData("+mohammad", "mohammad")]
        [InlineData("-ali", "ali")]
        [InlineData("reza", "reza")]
        public void Tag_ShouldProcessWordsCorrectly_ForAllTagTypes(string command, string word)
        {
            var tagged = _tagProcessor.Process(command);
            Assert.Equal(tagged.Word, word);
        }
    }
}