using System;
using System.Collections.Generic;
using static SearchTest.TestEssentials;
using System.Linq;
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
            _wordProcessor = new WordProcessor();
        }

        private void InitializeFields()
        {
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
            var seperatedText =  new[]
            {
                "Advice",
                "me",
                "cousin",
                "an",
                "spring",
                "of",
                "needed"
            };
           var returnValue = new List<object[]>()
           {
               new object[]{ text, seperatedText }
           };
           return returnValue;
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