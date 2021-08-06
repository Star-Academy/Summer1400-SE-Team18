using System.Collections.Generic;
using System.Linq;
using Scores.Model;

namespace Scores.Controller.Calculators
{
    public class AverageCalculator : ICalculator
    {
        public StudentAndAverage[] Calculate(Student[] students, StudentScore[] studentsScores)
        {
            var studentsWithAverages = ReturnEachStudentWithAverage(students, studentsScores);
            return studentsWithAverages.ToArray();
        }

        private static IEnumerable<StudentAndAverage> ReturnEachStudentWithAverage(Student[] students,
            StudentScore[] scores)
        {
            return students.GroupJoin(scores

                // two below params map scores to each student 
                // if score.StudentNumber equals student.StudentNumber
                , student => student.StudentNumber
                , score => score.StudentNumber

                // lambda below creates a new object out of each student and its scores
                , (student, studentScores) =>
                {
                    var average = GetAverageOfStudentScores(studentScores);
                    return new StudentAndAverage(student, average);
                });
        }

        private static double GetAverageOfStudentScores(IEnumerable<StudentScore> studentScores)
        {
            try
            {
                return studentScores.Select(score => score.Score).Average();
            }
            catch
            {
                return double.NaN;
            }
        }
    }
}