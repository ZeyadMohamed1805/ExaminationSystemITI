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

        public List<Instructor> GetInstructors()
        {
            var instructors = _dbcontext.Instructors.FromSqlRaw("EXEC SelectAllInstructors").ToList();
            return instructors;
        }
    }
}
