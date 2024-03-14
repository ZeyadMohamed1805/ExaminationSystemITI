using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
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

        public ICollection<StudentExamCardViewModel> FindStudentExams(int Id)
        {
            var viewModel = new List<StudentExamCardViewModel>();
            var exams = _context.Exams.FromSqlInterpolated($"SELECT DISTINCT * FROM EXAMS JOIN STUDENTEXAMQUESTIONS ON EXAMS.ID = STUDENTEXAMQUESTIONS.EXAMID WHERE STUDENTEXAMQUESTIONS.STUDENTID = {Id}").ToList();

            for ( int index = 0; index < exams.Count(); index++) 
            {
                var model = new StudentExamCardViewModel();
                model.Exam = exams[index];
                model.Course = _context.Courses.FromSqlInterpolated($"SELECT * FROM COURSES WHERE ID = {model.Exam.ID}").ToList()[0];
                model.Instructors = _context.Instructors.FromSqlInterpolated($"SELECT * FROM INSTRUCTORS JOIN COURSEINSTRUCTOR ON INSTRUCTORS.ID = COURSEINSTRUCTOR.INSTRUCTORSID WHERE COURSEINSTRUCTOR.COURSESID = {model.Course.Id}").ToList();
                viewModel.Add(model);
            }
            return viewModel;
        }
    }
}
