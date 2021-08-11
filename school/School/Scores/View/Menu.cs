using System;
using System.Collections.Generic;
using System.Linq;
using Scores.Model;

namespace Scores.View
{
    public class Menu
    {
        private const string OutString = "Student: {0}-{1} ---> Score: {2}";

        public static void PrintHighScoreStudents(Dictionary<Student, double> highScoreStudents)
        {
            foreach (var studentAndAverage in highScoreStudents)
            {
                ShowMessage(studentAndAverage);
            }
        }

        private static void ShowMessage(KeyValuePair<Student, double> studentAndAverage)
        {
            Console.WriteLine(OutString,
                studentAndAverage.Key.FirstName,
                studentAndAverage.Key.LastName,
                studentAndAverage.Value);
        }
    }
}