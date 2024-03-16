using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Services
{
    public class UserService : IUserService
    {
        ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<User> GetUsers()
        {
            var users = _context.Users.FromSqlRaw("EXEC SelectAllUsers").ToList();
            return users;
        }

        public void DeleteUser(string email)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC DeleteUserById {email}");
        }

        public void EditUser(User user, string newEmail)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC EditUserById {user.Email},{newEmail},{user.Password}");
        }

        public void InsertUser(User user)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC InsertUser {user.Email}");
        }

        public User? FindUser(string email)
        {
            var user = _context.Users.Find(email);
            return user;
        }
    }
}
