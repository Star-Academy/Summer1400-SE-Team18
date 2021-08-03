using System.Collections.Generic;
using Scores.Model;

namespace Scores.Controller.Calculators
{
    public interface ICalculator
    {
        public Dictionary<Student, double> Calculate(Student[] students, StudentScore[] scores);
    }
}