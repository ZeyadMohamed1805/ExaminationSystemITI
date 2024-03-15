using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface IUserService
    {
        public ICollection<User> GetUsers();
        public void DeleteUser(string email);
        public void EditUser(User user, string newEmail);
        public void InsertUser(User user);
        public User? FindUser(string email);
    }
}
