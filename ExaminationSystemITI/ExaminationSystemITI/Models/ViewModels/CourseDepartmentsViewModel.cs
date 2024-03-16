using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class CourseDepartmentsViewModel
    {
        public Course Course { get; set; }
        public ICollection<int> Departments { get; set; } = new HashSet<int>();
    }
}
