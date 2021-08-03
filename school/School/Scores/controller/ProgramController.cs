using Scores.controller.calculators;
using Scores.controller.parser;
using Scores.controller.reader;

namespace Scores.controller
{
    public class ProgramController
    {
        
        public static IReader FileReader { get; set; }
        public static IJson JsonParser { get; set; }
        public static ICalculator AverageCalculator { get; set; }
        public static ICalculator HighScoreCalculator { get; set; }
        public static ProcessData ProcessData { get; set; }
        
        public static void Run()
        {
            Initializer();
            ProcessData.Process();
        }

        private static void Initializer()
        {
            FileReader = new FileReader();
            JsonParser = new JsonParser();
            AverageCalculator = new AverageCalculator();
            HighScoreCalculator = new HighScoreCalculator();
            ProcessData = new ProcessData();
        }
    }
}