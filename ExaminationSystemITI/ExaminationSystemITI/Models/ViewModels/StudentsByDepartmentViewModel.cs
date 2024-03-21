using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Models.ViewModels
{
    public class StudentsByDepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }
    }
}
