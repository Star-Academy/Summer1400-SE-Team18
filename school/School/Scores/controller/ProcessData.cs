using System.Collections.Generic;
using Scores.model;
using Scores.view;

namespace Scores.controller
{
    public class ProcessData
    {
        public void Process()
        {
            var students = getStudentsFromJsonFile("Database/Students.json");
            var scores = getStudentScoresFromJsonFile("Database/Scores.json");
            var highScores = ProgramController.HighScoreCalculator.Calculate(students, scores);
            Menu.PrintHighScoreStudents(highScores);
        }

        private Student[] getStudentsFromJsonFile(string studentsFilePath)
        {
            string studentsData = ProgramController.FileReader.Read(studentsFilePath);
            return ProgramController.JsonParser.GetObjectsArray<Student[]>(studentsData);
        }

        private StudentScore[] getStudentScoresFromJsonFile(string studentScoresFilePath)
        {
            string studentScoresData = ProgramController.FileReader.Read(studentScoresFilePath);
            return ProgramController.JsonParser.GetObjectsArray<StudentScore[]>(studentScoresData);
        }
    }
}