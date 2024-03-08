using ExaminationSystemITI.Abstractions.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemITI.Models.Tables
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int StudentAge { get; set; }
        public EGender StudentGender { get; set; }
        public string StudentAddress { get; set; }
        public string StudentFaculty { get; set; }
        public int StudentGraduationYear { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<StudentExamQuestion> StudentExamQuestions { get; set; }
        public Department Department { get; set; }
        public string UserEmail { get; set; }
        [ForeignKey("UserEmail")]
        public User User { get; set; }
    }
}
