using ExaminationSystemITI.Abstractions.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemITI.Models.Tables
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public EGender Gender { get; set; }
        public string? Address { get; set; }
        public string Faculty { get; set; }
        public int GraduationYear { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<StudentExamQuestion> StudentExamQuestions { get; set; }
        public int DepartmentId {  get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public string Email { get; set; }
        [ForeignKey("Email")]
        public User User { get; set; }

        public Student()
        {
           
            StudentCourses = new List<StudentCourse>();
        }
    }
}
