using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface IAdminService
    {
        public ICollection<Admin> GetAdmins();

        public void DeleteAdmin(int Id);

        public void EditAdmin(Admin admin);

        //public void InsertCourse(Course course);

        public Admin? FindAdmin(int Id);
    }
}
