using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemITI.Models.Tables
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Grade { get; set; }
        public string Description { get; set; }
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
        public ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Question> Questions { get; set; }

        public Course()
        {

            StudentCourses = new List<StudentCourse>();
        }
    }
}
