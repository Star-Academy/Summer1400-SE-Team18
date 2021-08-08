using System.Collections.Generic;
using System.Linq;
using Scores.Model;

namespace Scores.Controller.Calculators
{
    public class HighScoreCalculator : ICalculator
    {
        public Dictionary<int, double> Calculate(StudentScore[] studentsScores)
        {
            var averageCalculator = ProgramController.AverageCalculator;
            var studentsWithAverage = averageCalculator.Calculate(studentsScores);
            var sortedList = SortStudentsByAverage(studentsWithAverage);
            return ReturnProperSizeOfSortedList(sortedList);
        }

        private IEnumerable<KeyValuePair<int, double>> SortStudentsByAverage(Dictionary<int, double> averages)
        {
            var sorted = averages.OrderByDescending(element => element.Value);
            return sorted;
        }

        private Dictionary<int, double> ReturnProperSizeOfSortedList(IEnumerable<KeyValuePair<int, double>> averages)
        {
            var keyValuePairs = averages as KeyValuePair<int, double>[] ?? averages.ToArray();
            try
            {
                return GetDictionary(keyValuePairs.Take(3));
            }
            catch
            {
                return GetDictionary(keyValuePairs);
            }
        }

        private Dictionary<int, double> GetDictionary(IEnumerable<KeyValuePair<int, double>> averages)
        {
            return averages
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}