using System;
using System.Collections.Generic;
using static SearchTest.TestEssentials;
using System.Linq;
using Iveonik.Stemmers;
using NSubstitute;
using Search.Word;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class WordProcessorTest
    {
        private WordProcessor _wordProcessor;

        public WordProcessorTest()
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            var stemmer = Substitute.For<ICustomStemmer>();
            stemmer.Stem(Arg.Any<string>()).Returns(x => x.Arg<string>());
            _wordProcessor = new WordProcessor(stemmer);
        }

        [Theory]
        [MemberData(nameof(Get_Parser_ShouldParseNormalText_TestData))]
        public void Parser_ShouldParseNormalText(string text, string[] expected)
        {
            var parsedText = _wordProcessor.ParseText(text);
            Assert.Equal(expected, parsedText);
        }

        public static IEnumerable<Object[]> Get_Parser_ShouldParseNormalText_TestData()
        {
            const string text = "Advice me cousin an spring of needed.";
            var returnValue =  new[]
            {
                "Advice",
                "me",
                "cousin",
                "an",
                "spring",
                "of",
                "needed"
            };
           var a = new List<object[]>()
           {
               new object[]{ text, returnValue }
           };
           return a;
        }

        [Theory]
        [MemberData(nameof(Get_Parser_ShouldParseText_WhenItsNonAlphabetical_TestData))]
        public void Parser_ShouldParseText_WhenItsNonAlphabetical(string text, string[] expected)
        {
            var parsedText = _wordProcessor.ParseText(text);
            Assert.Equal(expected, parsedText);
        }

        public static IEnumerable<Object[]> Get_Parser_ShouldParseText_WhenItsNonAlphabetical_TestData()
        {
            const string text = "Detract111222333 his general2222. If in so bred at da##*()(((((()))re rose lose go444od.";
            var returnValue =  new[]
            {
                "Detract",
                "his",
                "general",
                "If",
                "in",
                "so",
                "bred",
                "at",
                "da",
                "re",
                "rose",
                "lose",
                "go",
                "od"
            };
            return new List<object[]>()
            {
                new object[] { text, returnValue}
            };
        }
    }
}