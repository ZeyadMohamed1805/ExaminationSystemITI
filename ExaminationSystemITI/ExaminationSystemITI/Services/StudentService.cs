using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Services
{
    public class StudentService : IStudentService
    {
        ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context) 
        {
            _context = context;       
        }
 
        public void Add(Student student)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC InsertUser {student.Email}");
            _context.Database.ExecuteSqlInterpolated($"EXEC InsertRoleUser 2, {student.Email}");
            _context.Database.ExecuteSqlInterpolated($"EXEC InsertStudent {student.FirstName},{student.LastName},{student.Age},{student.Gender},{student.Address},{student.Faculty},{student.GraduationYear},{student.Email},{student.DepartmentId}");
            student = _context.Students.SingleOrDefault( std => std.Email == student.Email  );
            _context.Database.ExecuteSqlInterpolated($"EXEC InsertStudentCoursesByDepartmentId {student.Id}, {student.DepartmentId};");
        }

        public List<Course> GetStudentCourses(int Id)
        {
            var courses = _context.Courses.FromSqlInterpolated($"SELECT COURSES.ID, COURSES.NAME, COURSES.GRADE, COURSES.DESCRIPTION FROM COURSES JOIN STUDENTCOURSES ON COURSES.ID = STUDENTCOURSES.COURSEID WHERE STUDENTCOURSES.STUDENTID = {Id}").ToList();
            return courses;
        }
     
        public void Delete(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC DeleteStudentById {id}");
            //var std=GetById(id);
            //_context.Remove(std);
            //_context.SaveChanges();
        }



     
        public List<Student> GetAll()
        {

            var students = _context.Students.FromSqlRaw("EXEC SelectAllStudents").ToList();
            foreach (var student in students)
            {
                student.Department = _context.Departments.FromSql($"EXEC SelectDepartmentById {student.DepartmentId}").ToList()[0];
            }



            //all sttudents join with department

            //var students = _context.Students
            //     .FromSqlRaw("EXEC SelectAllStudentsWithDepartments")
            //     .ToList();

            return students;
        }


        public Student GetById(int id)
        {

            var std = _context.Students.FromSql($"EXEC SelectStudentById {id}").ToList()[0];
            std.Department = _context.Departments.FromSql($"EXEC SelectDepartmentById {std.DepartmentId}").ToList()[0];
            return std;

        }
        
        public void Update(Student student)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC EditStudentById {student.Id},{student.FirstName},{student.LastName},{student.Age},{student.Gender},{student.Address},{student.Faculty},{student.GraduationYear}, {student.DepartmentId}");
  
        }


    }
}
