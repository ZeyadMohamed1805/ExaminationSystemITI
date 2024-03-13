using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Services
{
    public class CourseService : ICourseService
    {
        ApplicationDbContext _context;
        public CourseService( ApplicationDbContext context ) 
        {
            _context = context;
        }
        public ICollection<Course> GetCourses()
        {
            var courses = _context.Courses.FromSqlRaw("EXEC SelectAllCourses").ToList();

            foreach( var course in courses )
            {
                course.Topics = new TopicService(_context).GetCourseTopics(course.Id);
                course.Departments = _context.Departments.FromSqlInterpolated($"SELECT * FROM DEPARTMENTS JOIN COURSEDEPARTMENT ON COURSEDEPARTMENT.COURSESID = {course.Id}").ToList();
                course.Instructors = _context.Instructors.FromSqlInterpolated($"SELECT * FROM INSTRUCTORS JOIN COURSEINSTRUCTOR ON COURSEINSTRUCTOR.COURSESID = {course.Id}").ToList();
                course.CourseStudents = _context.StudentCourses.FromSqlInterpolated($"SELECT * FROM STUDENTCOURSES WHERE COURSEID = {course.Id}").ToList();
                course.CourseStudents = _context.StudentCourses.FromSqlInterpolated($"SELECT * FROM STUDENTCOURSES WHERE COURSEID = {course.Id}").ToList();
            }
                 
            return courses;
        }

        public void DeleteCourse(int Id)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC DeleteCourseById {Id}");
        }

        public void EditCourse(Course course)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC EditCourseById {course.Id},{course.Name},{course.Grade}");
        }

        public void InsertCourse(Course course)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC InsertCourse {course.Name},{course.Grade}");
        }

        public Course? FindCourse(int Id)
        {
            var course = _context.Courses.Find(Id);
            return course;
        }
    }
}
