using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class StudentDepartmentsViewModel
    {
        public Student Student { get; set; }
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
