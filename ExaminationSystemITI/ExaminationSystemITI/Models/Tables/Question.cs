using ExaminationSystemITI.Abstractions.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemITI.Models.Tables
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]
        public EQuestionType QuestionType { get; set; }
        [Required]
        public string QuestionTitle { get; set; }
        [Required]
        public string QuestionCorrectAnswer { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
        public ICollection<Choice> Chioces { get; set; } = new HashSet<Choice>();
        public ICollection<StudentExamQuestion> StudentExamQuestions { get; set; }
    }
}
