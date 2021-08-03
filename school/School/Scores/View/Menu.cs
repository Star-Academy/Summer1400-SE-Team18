using System;
using System.Collections.Generic;
using Scores.Model;

namespace Scores.View
{
    public class Menu
    {
        public static void PrintHighScoreStudents(Dictionary<Student, double> highScoreStudents)
        {
            foreach (var highScoreStudent in highScoreStudents)
            {
                ShowMessage("Student: " + highScoreStudent.Key.FirstName + "-" + highScoreStudent.Key.LastName 
                            + " ---> Score: " + highScoreStudent.Value);
            }
        }

        private static void ShowMessage(String message)
        {
            Console.WriteLine(message);
        }
    }
}