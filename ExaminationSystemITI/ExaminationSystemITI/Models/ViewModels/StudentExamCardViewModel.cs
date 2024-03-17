using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class StudentExamCardViewModel
    {
        public Course Course { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public Exam Exam { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
