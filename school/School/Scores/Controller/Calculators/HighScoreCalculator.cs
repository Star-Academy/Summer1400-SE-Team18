using System.Collections.Generic;
using System.Linq;
using Scores.Model;

namespace Scores.Controller.Calculators
{
    public class HighScoreCalculator : ICalculator
    {
        public StudentAndAverage[] Calculate(Student[] students, StudentScore[] studentsScores)
        {
            var averageCalculator = ProgramController.AverageCalculator;
            var studentsWithAverage = averageCalculator.Calculate(students, studentsScores);
            var sortedList = SortStudentsByAverage(studentsWithAverage);
            return ReturnProperSizeOfSortedList(sortedList);
        }

        private IEnumerable<StudentAndAverage> SortStudentsByAverage(StudentAndAverage[] averages)
        {
            // sorts by StudentAndAverage.Average
            var sorted = averages.OrderByDescending(element => element.Average);
            return sorted;
        }

        private StudentAndAverage[] ReturnProperSizeOfSortedList(IEnumerable<StudentAndAverage> averages)
        {
            try
            {
                return averages.Take(3).ToArray();
            }
            catch
            {
                return averages.ToArray();
            }
        }
    }
}