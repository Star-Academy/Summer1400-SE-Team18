using NSubstitute;
using Search.Tags;
using Search.Word;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class TagProcessorTest
    {

        private ITagProcessor _tagProcessor;
        
        public TagProcessorTest()
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            var customStemmer = Substitute.For<ICustomStemmer>();
            customStemmer.Stem(Arg.Any<string>()).Returns(x => x.Arg<string>());
            _tagProcessor = new TagProcessor(customStemmer);
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