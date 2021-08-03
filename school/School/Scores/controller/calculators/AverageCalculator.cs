using System;
using System.Collections.Generic;
using Scores.model;
using System.Linq;

namespace Scores.controller.calculators
{
    public class AverageCalculator : ICalculator
    {

        public Dictionary<Student, double> Calculate(Student[] students, StudentScore[] studentsScores)
        {
            var query = students.GroupJoin(studentsScores
                , student => student.StudentNumber
                , score => score.StudentNumber
                , (student, scores) =>
                {
                    var studentScores = scores as StudentScore[] ?? scores.ToArray();
                    return new
                    {
                        Student = student,
                        Average = !studentScores.Any()
                            ? 0
                            : studentScores.Select(score => score.Score).Aggregate((current,
                                next) => current + next) / studentScores.Count()
                    };
                }).ToDictionary(studentAndAverage => studentAndAverage.Student
                , studentAndAverage => studentAndAverage.Average);
            return query;
        }
    }
}