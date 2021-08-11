using System.Collections.Generic;
using Scores.Model;

namespace Scores.Controller.Calculators
{
    public interface ICalculator
    {
        public Dictionary<int, double> Calculate(StudentScore[] scores);
    }
}