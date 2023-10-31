namespace SKC_MVC.Models
{
    public class Grades
    {
        public int Id { get; set; }
        public int Homeworks { get; set; }
        public int FinalExam { get; set; }
        public int TotalGrades { get; set; }
        public int Exam1 { get; set; }
        public int Exam2 { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
