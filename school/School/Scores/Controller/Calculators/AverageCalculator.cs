using System.Collections.Generic;
using System.Linq;
using Scores.Model;

namespace Scores.Controller.Calculators
{
    public class AverageCalculator : ICalculator
    {

        public Dictionary<Student, double> Calculate(Student[] students, StudentScore[] studentsScores)
        {
            return students.GroupJoin(studentsScores
                , student => student.StudentNumber
                , score => score.StudentNumber
                , (student, scores) =>
                {
                    var studentScores = scores.ToArray();
                    return new
                    {
                        Student = student,
                        Average = GetAverageOfStudentScores(studentScores)
                    };
                }).ToDictionary(studentAndAverage => studentAndAverage.Student
                , studentAndAverage => studentAndAverage.Average);
        }

        private double GetAverageOfStudentScores(StudentScore[] studentScores)
        {
            return !studentScores.Any() ? 0 : studentScores.Select(score => score.Score).Average();
        }
    }
}