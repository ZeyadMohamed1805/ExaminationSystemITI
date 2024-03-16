using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class ExamCourseQuestionViewModel
    {
        public Exam Exam { get; set; }
        public ICollection<Course>Courses { get; set; }=new HashSet<Course>();
        public ICollection<Question> Questions { get; set;} =new HashSet<Question>();
    }
}
