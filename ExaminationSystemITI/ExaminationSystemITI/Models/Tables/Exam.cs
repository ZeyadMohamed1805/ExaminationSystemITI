using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Exam
    {
        [Key]
        public int ID { get; set; }
        
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        
        public int QCount { get; set; }
        
        public int TotalMarks { get; set; }
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public ICollection<StudentExamQuestion> StudentExamQuestions { get; set; }
    }
}
