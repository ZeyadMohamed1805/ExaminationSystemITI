using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class StudentExamCardViewModel
    {
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        public Exam Exam { get; set; }
        public Question Question { get; set; }
    }
}
