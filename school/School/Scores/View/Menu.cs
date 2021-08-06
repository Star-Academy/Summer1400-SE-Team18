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
            highScoreStudents.All(highScoreStudent =>
            {
                ShowMessage(highScoreStudent);
                return true;
            });
        }

        private static void ShowMessage(KeyValuePair<Student, double> highScoreStudent)
        {
            Console.WriteLine(OutString, 
                highScoreStudent.Key.FirstName, 
                highScoreStudent.Key.LastName, 
                highScoreStudent.Value);
        }
    }
}