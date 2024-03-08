using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public int CourseGrade { get; set; }
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
        public ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();
        public ICollection<StudentCourse> CourseStudents { get; set; }
    }
}
