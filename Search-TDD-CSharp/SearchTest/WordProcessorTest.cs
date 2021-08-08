using System;
using System.Collections.Generic;
using static SearchTest.TestEssentials;
using System.Linq;
using Iveonik.Stemmers;
using Search.Word;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class WordProcessorTest
    {
        private WordProcessor _wordProcessor;
        private ICustomStemmer _stemmer;
        
        private const string FirstTest = "Advice me cousin an spring of needed. Tell use paid law ever yet new. Meant to learn of vexed" +
        " if style allow he there. Tiled man stand tears ten joy there terms any widen." +
        " Procuring continued suspicion its ten. Pursuit brother are had fifteen distant has." +
        " Early had add equal china quiet visit. Appear an manner as no limits either praise in." +
        " In in written on charmed justice is amiable farther besides. Law insensible middletons" +
        " unsatiable for apartments boy delightful unreserved.Admiration we surrounded possession" +
        " frequently he. Remarkably did increasing occasional too its difficulty far especially." +
        " Known tiled but sorry joy balls. Bed sudden manner indeed fat now feebly. Face do with in" +
        " need of wife paid that be. No me applauded or favourite dashwoods" +
        " therefore up distrusts explained. ";
        
        private const string SecondText = "Detract111222333 yet delight written farther11111 his general2222. If in so bred" +
                                     " at da##*()(((((()))re rose lose go444od. Feel and make two real miss use ea12331" +
                                     "23sy. Celebrated delightful an";

        public WordProcessorTest()
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            IStemmer englishStemmer = new EnglishStemmer();
            _stemmer = new Stemmer(englishStemmer);
            _wordProcessor = new WordProcessor(_stemmer);
        }

        [Theory]
        [MemberData(nameof(Get_Parser_ShouldParseNormalText_TestData))]
        public void Parser_ShouldParseNormalText(string[] expected)
        {
            var parsedText = _wordProcessor.ParseText(FirstTest);
            Assert.Equal(expected, parsedText);
        }

        public static IEnumerable<Object[]> Get_Parser_ShouldParseNormalText_TestData()
        {
            var returnValue =  new[]
            {
                "Advice",
                "me",
                "cousin",
                "an",
                "spring",
                "of",
                "needed",
                "Tell",
                "use",
                "paid",
                "law",
                "ever",
                "yet",
                "new",
                "Meant",
                "to",
                "learn",
                "of",
                "vexed",
                "if",
                "style",
                "allow",
                "he",
                "there",
                "Tiled",
                "man",
                "stand",
                "tears",
                "ten",
                "joy",
                "there",
                "terms",
                "any",
                "widen",
                "Procuring",
                "continued",
                "suspicion",
                "its",
                "ten",
                "Pursuit",
                "brother",
                "are",
                "had",
                "fifteen",
                "distant",
                "has",
                "Early",
                "had",
                "add",
                "equal",
                "china",
                "quiet",
                "visit",
                "Appear",
                "an",
                "manner",
                "as",
                "no",
                "limits",
                "either",
                "praise",
                "in",
                "In",
                "in",
                "written",
                "on",
                "charmed",
                "justice",
                "is",
                "amiable",
                "farther",
                "besides",
                "Law",
                "insensible",
                "middletons",
                "unsatiable",
                "for",
                "apartments",
                "boy",
                "delightful",
                "unreserved",
                "Admiration",
                "we",
                "surrounded",
                "possession",
                "frequently",
                "he",
                "Remarkably",
                "did",
                "increasing",
                "occasional",
                "too",
                "its",
                "difficulty",
                "far",
                "especially",
                "Known",
                "tiled",
                "but",
                "sorry",
                "joy",
                "balls",
                "Bed",
                "sudden",
                "manner",
                "indeed",
                "fat",
                "now",
                "feebly",
                "Face",
                "do",
                "with",
                "in",
                "need",
                "of",
                "wife",
                "paid",
                "that",
                "be",
                "No",
                "me",
                "applauded",
                "or",
                "favourite",
                "dashwoods",
                "therefore",
                "up",
                "distrusts",
                "explained"
            };
           IStemmer stemmer = new EnglishStemmer();
           returnValue = returnValue.Select(s => stemmer.Stem(s.ToLower())).ToArray();
           var a = new List<object[]>()
           {
               new object[]{returnValue}
           };
           return a;
        }

        [Theory]
        [MemberData(nameof(Get_Parser_ShouldParseText_WhenItsNonAlphabetical_TestData))]
        public void Parser_ShouldParseText_WhenItsNonAlphabetical(string[] expected)
        {
            var parsedText = _wordProcessor.ParseText(SecondText);
            Assert.Equal(expected, parsedText);
        }

        public static IEnumerable<Object[]> Get_Parser_ShouldParseText_WhenItsNonAlphabetical_TestData()
        {
            var returnValue =  new[]
            {
                "Detract",
                "yet",
                "delight",
                "written",
                "farther",
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
                "od",
                "Feel",
                "and",
                "make",
                "two",
                "real",
                "miss",
                "use",
                "ea",
                "sy",
                "Celebrated",
                "delightful",
                "an"
            };
            IStemmer stemmer = new EnglishStemmer();
            returnValue = returnValue.Select(s => stemmer.Stem(s.ToLower())).ToArray();
            return new List<object[]>()
            {
                new object[] { returnValue}
            };
        }
    }
}