using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{  
    //for instructor in exam controller
    public class ExamCourses
    {
        public List<Exam> Exams { get; set; }
        public List<Course> Courses { get; set; }

    }
}
