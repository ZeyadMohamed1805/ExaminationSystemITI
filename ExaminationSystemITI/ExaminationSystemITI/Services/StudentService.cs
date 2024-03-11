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
            _context.Database.ExecuteSqlInterpolated($"EXEC InsertStudent {student.FirstName},{student.LastName},{student.Age},{student.Gender},{student.Address},{student.Faculty},{student.GraduationYear},{student.Email},{student.DepartmentId}");        
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
           // var students=_context.Students.FromSqlRaw("Exec SelectAllStudents").Include(a=>a.Department).ToList();
            var students = _context.Students.FromSqlRaw("EXEC SelectAllStudents").ToList();
            foreach ( var student in students )
            {
                student.Department=_context.Departments.FromSql($"EXEC SelectDepartmentById {student.DepartmentId}").ToList()[0];
            }

            return students;
        }


        public Student GetById(int id)
        {

            var std = _context.Students.FromSql($"EXEC SelectStudentById {id}").ToList()[0];
            std.Department = _context.Departments.FromSql($"EXEC SelectDepartmentById {std.DepartmentId}").ToList()[0];
            //var student = _context.Students.SingleOrDefault(a=>a.Id==id);
            //return student;
            return std;

        }
        
        public void Update(Student student)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC EditStudentById {student.Id},{student.FirstName},{student.LastName},{student.Age},{student.Gender},{student.Address},{student.Faculty},{student.GraduationYear}");
  
        }


    }
}
