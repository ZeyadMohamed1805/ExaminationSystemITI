using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class InstructorCoursesViewModel
    {
        public Instructor Instructor { get; set; }
        public List<Course> Courses { get; set; }
        public List<int> ? CourseIds { get; set; }
    }
}
