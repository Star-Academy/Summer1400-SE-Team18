using System.Linq;
using Scores.Model;
using Scores.View;

namespace Scores.Controller
{
    public class ProcessData
    {
        public void Process()
        {
            var students = GetStudentsFromJsonFile("Database/Students.json");
            var scores = GetStudentScoresFromJsonFile("Database/Scores.json");
            var highScores = ProgramController.HighScoreCalculator.Calculate(scores);
            var query = highScores
                .ToDictionary(k => GetStudetByID(students, k.Key), v => v.Value);
            Menu.PrintHighScoreStudents(query);
        }

        private Student[] GetStudentsFromJsonFile(string studentsFilePath)
        {
            string studentsData = ProgramController.FileReader.Read(studentsFilePath);
            return ProgramController.JsonParser.GetObjectsArray<Student[]>(studentsData);
        }

        private StudentScore[] GetStudentScoresFromJsonFile(string studentScoresFilePath)
        {
            string studentScoresData = ProgramController.FileReader.Read(studentScoresFilePath);
            return ProgramController.JsonParser.GetObjectsArray<StudentScore[]>(studentScoresData);
        }

        private static Student GetStudetByID(Student[] students, int ID)
        {
            return students.First(s => s.StudentNumber == ID);
        }
    }
}