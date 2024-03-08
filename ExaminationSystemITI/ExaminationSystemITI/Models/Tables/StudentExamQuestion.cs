namespace ExaminationSystemITI.Models.Tables
{
    public class StudentExamQuestion
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public Question Question { get; set; }
    }
}
