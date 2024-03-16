using ExaminationSystemITI.Abstractions.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemITI.Models.Tables
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        
        public EQuestionType Type { get; set; }
        
        public string Title { get; set; }
        
        public string CorrectAnswer { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
        public ICollection<Choice> Choices { get; set; } = new HashSet<Choice>();
        public ICollection<StudentExamQuestion> StudentExamQuestions { get; set; }
    }
}

