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
            ICustomStemmer customStemmer = Substitute.For<ICustomStemmer>();
            MockCustomStemmer(customStemmer);
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

        private void MockCustomStemmer(ICustomStemmer customStemmer)
        {
            customStemmer.Stem("mohammad").Returns("mohammad");
            customStemmer.Stem("ali").Returns("ali");
            customStemmer.Stem("reza").Returns("reza");
        }
    }
}