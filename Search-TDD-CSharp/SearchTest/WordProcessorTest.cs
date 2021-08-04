using NSubstitute;
using Xunit;
using Search.WordProcessor;

namespace SearchTest
{
    public class WordProcessorTest
    {
        private IWordProcessor _wordProcessor;

        [Fact]
        public void Should_Parse_Text()
        {
            var expected = new string[]
            {
                "Detract" ,
                "yet" ,
                "delight" ,
                "written" ,
                "farther" ,
                "his" ,
                "general" ,
                "If" ,
                "in" ,
                "so" ,
                "bred" ,
                "at" ,
                "da" ,
                "re" ,
                "rose" ,
                "lose" ,
                "go" ,
                "od" ,
                "Feel" ,
                "and" ,
                "make" ,
                "two" ,
                "real" ,
                "miss" ,
                "use" ,
                "ea" ,
                "sy" ,
                "Celebrated" ,
                "delightful" ,
                "an"
            };
            var text = "Detract111222333 yet delight written farther11111 his general2222. If in so bred" +
                       " at da##*()(((((()))re rose lose go444od. Feel and make two real miss use ea1233123sy. Celebrated delightful an";
            var parsedText = _wordProcessor.ParseText(text);
            Assert.Equal(expected, parsedText);
        }
    }
}