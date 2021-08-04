using System.Linq;
using Search.Dependencies;
using Search.Word;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class WordProcessorTest
    {
        private IWordProcessor _wordProcessor = new WordProcessor();

        public WordProcessorTest()
        {
            Manager.Reset();
        }

        [Fact]
        public void Should_Parse_Normal_text()
        {
            var expected = new[]
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
            expected = expected.Select(s => _wordProcessor.GetStem(s.ToLower())).ToArray();
            var text = "Advice me cousin an spring of needed. Tell use paid law ever yet new. Meant to learn of vexed" +
                       " if style allow he there. Tiled man stand tears ten joy there terms any widen." +
                       " Procuring continued suspicion its ten. Pursuit brother are had fifteen distant has." +
                       " Early had add equal china quiet visit. Appear an manner as no limits either praise in." +
                       " In in written on charmed justice is amiable farther besides. Law insensible middletons" +
                       " unsatiable for apartments boy delightful unreserved.Admiration we surrounded possession" +
                       " frequently he. Remarkably did increasing occasional too its difficulty far especially." +
                       " Known tiled but sorry joy balls. Bed sudden manner indeed fat now feebly. Face do with in" +
                       " need of wife paid that be. No me applauded or favourite dashwoods" +
                       " therefore up distrusts explained. ";
            var parsedText = _wordProcessor.ParseText(text);
            Assert.Equal(expected, parsedText);
        }

        [Fact]
        public void Should_Parse_Text_When_There_Is_Non_Alphabetical()
        {
            var expected = new[]
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
            expected = expected.Select(s => _wordProcessor.GetStem(s.ToLower())).ToArray();
            var text = "Detract111222333 yet delight written farther11111 his general2222. If in so bred" +
                       " at da##*()(((((()))re rose lose go444od. Feel and make two real miss use ea1233123sy. Celebrated delightful an";
            var parsedText = _wordProcessor.ParseText(text);
            Assert.Equal(expected, parsedText);
        }
    }
}