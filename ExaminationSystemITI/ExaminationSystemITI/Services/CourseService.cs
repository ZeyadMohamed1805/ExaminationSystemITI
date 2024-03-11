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
