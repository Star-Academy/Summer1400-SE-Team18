using System;
using Iveonik.Stemmers;
using Xunit;


namespace SearchTest
{
    public class TestClass1
    {
        [Fact]
        public void Test1()
        {
            string a = new EnglishStemmer().Stem("this");
        }
    }
}