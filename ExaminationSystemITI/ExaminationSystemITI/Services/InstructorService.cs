using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExaminationSystemITI.Services
{
    public class InstructorService : IInstructorService
    {
        ApplicationDbContext _dbcontext;
        public InstructorService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void DeleteInstructor(int insID)
        {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC DeleteInstructorById {insID}");
        }

        public void EditInstructor(Instructor ins)
        {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC EditInstructorById {ins.ID},{ins.FirstName},{ins.LastName},{ins.Age},{ins.Salary},{ins.Address}");
        }

        public List<Instructor> GetInstructors()
        {
            var instructors = _dbcontext.Instructors.FromSqlRaw("EXEC SelectAllInstructors").ToList();
            return instructors;
        }

        public void InsertInstructor(Instructor ins)
        {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC InsertUser {ins.Email}");

            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC InsertInstructor {ins.FirstName},{ins.LastName},{ins.Age},{ins.Salary},{ins.Address},{ins.Email}");
        }

        public Instructor FindInstructor(int id)
        {
           var instructor= _dbcontext.Instructors.Find(id);
            return instructor;
        }
    }
}
