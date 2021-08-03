using System.Collections.Generic;
using Scores.model;

namespace Scores.controller.calculators
{
    public interface ICalculator
    {
        public Dictionary<Student, double> Calculate(Student[] students, StudentScore[] scores);
    }
}