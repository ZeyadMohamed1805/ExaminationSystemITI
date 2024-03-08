using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Exam
    {
        public int ExamID { get; set; }
        [Required]
        public int ExamDuration { get; set; }
        public DateTime ExamDate { get; set; }

        public int ExamQCount { get; set; }
        public int ExamTotalMarks { get; set; }

        public int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }
    }
}
