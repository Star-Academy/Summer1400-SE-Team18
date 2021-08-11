using System;
using System.Collections.Generic;
using System.Linq;
using Scores.Model;

namespace Scores.Controller.Calculators
{
    public class AverageCalculator : ICalculator
    {
        public Dictionary<int, double> Calculate(StudentScore[] studentsScores)
        {
            var scores = ReturnEachStudentWithAverage(studentsScores);
            return scores;
        }

        private static Dictionary<int, double> ReturnEachStudentWithAverage(StudentScore[] scores)
        {
            return scores.GroupBy(s => s.StudentNumber)
                .ToDictionary(k => k.Key, GetAverageOfStudentScores);
        }

        private static double GetAverageOfStudentScores(IGrouping<int,StudentScore> studentScores)
        {
            return studentScores.ToList().Average(s => s.Score);
        }
    }
}