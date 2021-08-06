using System.Collections.Generic;
using Scores.Model;

namespace Scores.Controller.Calculators
{
    public interface ICalculator
    {
        public StudentAndAverage[] Calculate(Student[] students, StudentScore[] scores);
    }
}