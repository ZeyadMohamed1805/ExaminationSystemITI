using ExaminationSystemITI.Models.Tables;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartments();
        public void InsertDepartment(Department dep);
        public void EditDepartment(Department dep);
        public void DeleteDepartment(int depID);
        public Department FindDepartment(int id);
    }
}
