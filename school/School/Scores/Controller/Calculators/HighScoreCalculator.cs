using System.Collections.Generic;
using System.Linq;
using Scores.Model;

namespace Scores.Controller.Calculators
{
    public class HighScoreCalculator : ICalculator
    {
        public Dictionary<Student, double> Calculate(Student[] students, StudentScore[] studentsScores)
        {
            var result = ProgramController.AverageCalculator.Calculate(students, studentsScores);
            return
                result
                    .OrderByDescending(studentScore => studentScore.Value)
                    .Take(3)
                    .ToDictionary(studentScore => studentScore.Key
                        , studentScore => studentScore.Value);
        }
    }
}