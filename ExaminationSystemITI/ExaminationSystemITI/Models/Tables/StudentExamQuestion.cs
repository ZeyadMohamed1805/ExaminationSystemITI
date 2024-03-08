namespace ExaminationSystemITI.Models.Tables
{
    public class StudentExamQuestion
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public ICollection<Student> students { get; set; } = new HashSet<Student>();
        public ICollection<Exam> exams { get; set; } = new HashSet<Exam>();
        public ICollection<Question> questions { get; set; } = new HashSet<Question>();
    }
}
