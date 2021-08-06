namespace Scores.Model
{
    public class StudentAndAverage
    {
        public Student Student { get; set; }
        public double Average { get; }

        public StudentAndAverage(Student student, double average)
        {
            this.Average = average;
            this.Student = student;
        }
    }
}