using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
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

        public List<Course> GetInstructorCourses(int Id)
        {
            var courses = _dbcontext.Courses.FromSqlInterpolated($"SELECT * FROM COURSES JOIN COURSEINSTRUCTOR ON COURSES.ID = COURSEINSTRUCTOR.COURSESID WHERE COURSEINSTRUCTOR.INSTRUCTORSID = {Id}").ToList();
            return courses;
        }

        public List<Instructor> GetActiveSupervisors()
        {
            var supervisors = _dbcontext.Instructors.FromSqlInterpolated($"SELECT * FROM INSTRUCTORS WHERE ID NOT IN ( SELECT SP FROM DEPARTMENTS )").ToList();
            return supervisors;
        }

        public void InsertInstructor(Instructor ins)
        {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC InsertUser {ins.Email}");
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC InsertRoleUser 3, {ins.Email}");
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC InsertInstructor {ins.FirstName},{ins.LastName},{ins.Age},{ins.Salary},{ins.Address},{ins.Email}");
        }

        public void InsertInstructorCourses(InstructorCoursesViewModel viewModel)
        {
            foreach( var course in viewModel.CourseIds )
                _dbcontext.Database.ExecuteSqlInterpolated($"EXEC InsertCourseInstructor {course}, {viewModel.Instructor.ID}");
        }

        public Instructor FindInstructor(int id)
        {
           var instructor= _dbcontext.Instructors.Find(id);
            return instructor;
        }
    }
}
