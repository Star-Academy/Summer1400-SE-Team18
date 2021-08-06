using System;
using System.Collections.Generic;
using System.Linq;
using Scores.Model;

namespace Scores.View
{
    public class Menu
    {
        private const string OutString = "Student: {0}-{1} ---> Score: {2}";

        public static void PrintHighScoreStudents(StudentAndAverage[] highScoreStudents)
        {
            foreach (var studentAndAverage in highScoreStudents)
            {
                ShowMessage(studentAndAverage);
            }
        }

        private static void ShowMessage(StudentAndAverage studentAndAverage)
        {
            Console.WriteLine(OutString,
                studentAndAverage.Student.FirstName,
                studentAndAverage.Student.LastName,
                studentAndAverage.Average);
        }
    }
}