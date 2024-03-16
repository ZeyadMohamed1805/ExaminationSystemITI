using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class TopicCoursesViewModel
    {
        public Topic Topic { get; set; }
        public ICollection<Course>Courses { get; set; }=new HashSet<Course>();
    }
}
