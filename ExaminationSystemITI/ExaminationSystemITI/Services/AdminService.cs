using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Services
{
    public class AdminService : IAdminService
    {
        ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<Admin> GetAdmins()
        {
            var admins = _context.Admins.FromSqlRaw("SELECT * FROM ADMINS").ToList();
            return admins;
        }

        public void DeleteAdmin(int Id)
        {
            _context.Database.ExecuteSqlInterpolated($"DELETE FROM ADMINS WHERE ID = {Id}");
        }

        public void EditAdmin(Admin admin)
        {
            _context.Database.ExecuteSqlInterpolated($"UPDATE ADMINS SET FIRSTNAME = {admin.FirstName}, LASTNAME = {admin.LastName}, AGE = {admin.Age}, ADDRESS = {admin.Address}, GENDER = {admin.Gender} WHERE ID = {admin.Id}");
        }

        //public void InsertCourse(Course course)
        //{
        //    _context.Database.ExecuteSqlInterpolated($"EXEC InsertCourse {course.Name},{course.Grade}");
        //}

        public Admin? FindAdmin(int Id)
        {
            var admin = _context.Admins.Find(Id);
            return admin;
        }
    }
}
