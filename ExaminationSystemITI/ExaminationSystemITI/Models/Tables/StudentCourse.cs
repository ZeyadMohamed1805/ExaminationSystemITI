namespace ExaminationSystemITI.Models.Tables
{
    public class StudentCourse
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
