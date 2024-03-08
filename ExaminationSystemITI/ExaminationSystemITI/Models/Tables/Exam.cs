using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Exam
    {
        [Key]
        public int ExamID { get; set; }
        [Required]
        public int ExamDuration { get; set; }
        public DateTime ExamDate { get; set; }
        [Required]
        public int ExamQCount { get; set; }
        [Required]
        public int ExamTotalMarks { get; set; }
        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public ICollection<StudentExamQuestion> StudentExamQuestions { get; set; }
    }
}
