using System;
using Iveonik.Stemmers;
using static Iveonik.Stemmers.EnglishStemmer;

namespace Search
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            string a = new EnglishStemmer().Stem("stability");
            Console.WriteLine(a);
        }
    }
}