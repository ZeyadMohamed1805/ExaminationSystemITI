using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class StudentCoursesViewModel
    {
        public Student Student { get; set; }
        public List<Course> Courses { get; set; }
    }
}
