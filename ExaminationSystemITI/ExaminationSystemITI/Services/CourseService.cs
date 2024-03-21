using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                course.Departments = _context.Departments.FromSqlInterpolated($"SELECT * FROM DEPARTMENTS JOIN COURSEDEPARTMENT ON DEPARTMENTS.ID = COURSEDEPARTMENT.DEPARTMENTSID WHERE COURSEDEPARTMENT.COURSESID = {course.Id}").ToHashSet();
                course.Instructors = _context.Instructors.FromSqlInterpolated($"SELECT * FROM INSTRUCTORS JOIN COURSEINSTRUCTOR ON INSTRUCTORS.ID = COURSEINSTRUCTOR.INSTRUCTORSID WHERE COURSEINSTRUCTOR.COURSESID = {course.Id}").ToHashSet();
                course.StudentCourses = _context.StudentCourses.FromSqlInterpolated($"SELECT * FROM STUDENTCOURSES WHERE COURSEID = {course.Id}").ToHashSet();
            }
                 
            return courses;
        }

        public void DeleteCourse(int Id)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC DeleteCourseById {Id}");
        }

        public void EditCourse(Course course)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC EditCourseById {course.Id},{course.Name},{course.Grade}, {course.Description}");
        }

        public void InsertCourse(Course course)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC InsertCourse {course.Name}, {course.Description}, {course.Grade}");
        }

        public Course? FindCourse(int Id)
        {
            var course = _context.Courses.Find(Id);
            return course;
        }

        public void InsertCourseDepartments(CourseDepartmentsViewModel viewModel)
        {
            foreach( int department in viewModel.Departments )
                _context.Database.ExecuteSqlInterpolated($"INSERT INTO COURSEDEPARTMENT ( COURSESID, DEPARTMENTSID ) VALUES ( {viewModel.Course.Id}, {department} )");
        }

        public ICollection<StudentExamCardViewModel> FindStudentExams(int Id)
        {
            var viewModel = new List<StudentExamCardViewModel>();
            
            var exams = _context.Exams.FromSqlInterpolated($"SELECT EXAMS.ID, EXAMS.DURATION, EXAMS.DATE, EXAMS.QCOUNT, EXAMS.TOTALMARKS, EXAMS.COURSEID FROM EXAMS JOIN COURSES ON EXAMS.COURSEID = COURSES.ID WHERE COURSES.ID IN ( SELECT COURSEID FROM STUDENTCOURSES WHERE STUDENTID = {Id} )").ToList();

            for ( int index = 0; index < exams.Count(); index++) 
            {
                var model = new StudentExamCardViewModel();

                if (exams.Count() > 0)
                {
                    model.Exam = exams[index];
                    model.Course = _context.Courses.FromSqlInterpolated($"SELECT * FROM COURSES WHERE ID IN (SELECT COURSEID FROM EXAMS WHERE ID = {model.Exam.ID})").ToList()[0];
                    model.Instructors = _context.Instructors.FromSqlInterpolated($"SELECT * FROM INSTRUCTORS JOIN COURSEINSTRUCTOR ON INSTRUCTORS.ID = COURSEINSTRUCTOR.INSTRUCTORSID WHERE COURSEINSTRUCTOR.COURSESID = {model.Course.Id}").ToList();
                }

                viewModel.Add(model);
            }

            return viewModel;
        }

        public ICollection<StudentExamCardViewModel> FindStudentActiveExams(int Id)
        {
            var viewModel = new List<StudentExamCardViewModel>();
            //join with sc table not c . Join with st id also not only c id. 
            var exams = _context.Exams.FromSqlInterpolated($"SELECT EXAMS.ID, EXAMS.DURATION, EXAMS.DATE, EXAMS.QCOUNT, EXAMS.TOTALMARKS, EXAMS.COURSEID FROM EXAMS JOIN StudentCOURSES ON StudentCOURSES.CourseId = EXAMS.COURSEID WHERE StudentCOURSES.StudentId={Id} AND EXAMS.ID NOT IN ( SELECT DISTINCT EXAMID FROM StudentExamQuestions WHERE StudentId = {Id} )").ToList();
            for (int index = 0; index < exams.Count(); index++)
            {
                var model = new StudentExamCardViewModel();

                if (exams.Count() > 0)
                {
                    model.Exam = exams[index];
                    model.Course = _context.Courses.FromSqlInterpolated($"SELECT * FROM COURSES WHERE ID IN (SELECT COURSEID FROM EXAMS WHERE ID = {model.Exam.ID})").ToList()[0];
                    model.Instructors = _context.Instructors.FromSqlInterpolated($"SELECT * FROM INSTRUCTORS JOIN COURSEINSTRUCTOR ON INSTRUCTORS.ID = COURSEINSTRUCTOR.INSTRUCTORSID WHERE COURSEINSTRUCTOR.COURSESID = {model.Course.Id}").ToList();
                }

                viewModel.Add(model);
            }

            return viewModel;
        }

        public ICollection<StudentExamCardViewModel> FindStudentDoneExams(int Id)
        {
            var viewModel = new List<StudentExamCardViewModel>();

            var exams = _context.Exams.FromSqlInterpolated($"SELECT EXAMS.ID, EXAMS.DURATION, EXAMS.DATE, EXAMS.QCOUNT, EXAMS.TOTALMARKS, EXAMS.COURSEID FROM EXAMS JOIN COURSES ON COURSES.ID = EXAMS.COURSEID WHERE EXAMS.ID IN ( SELECT DISTINCT EXAMID FROM StudentExamQuestions WHERE StudentId = {Id} )").ToList();
            for (int index = 0; index < exams.Count(); index++)
            {
                var model = new StudentExamCardViewModel();

                if (exams.Count() > 0)
                {
                    bool isCourseAvailable = false;

                    foreach (var item in viewModel)
                    {
                        if (item.Course.Id == _context.Courses.FromSqlInterpolated($"SELECT * FROM COURSES WHERE ID IN (SELECT COURSEID FROM EXAMS WHERE ID = {exams[index].ID})").ToList()[0].Id)
                        { isCourseAvailable = true; break; }
                    }

                    if (isCourseAvailable)
                        continue;

                    model.Exam = exams[index];
                    model.Course = _context.Courses.FromSqlInterpolated($"SELECT * FROM COURSES WHERE ID IN (SELECT COURSEID FROM EXAMS WHERE ID = {model.Exam.ID})").ToList()[0];
                    model.Instructors = _context.Instructors.FromSqlInterpolated($"SELECT * FROM INSTRUCTORS JOIN COURSEINSTRUCTOR ON INSTRUCTORS.ID = COURSEINSTRUCTOR.INSTRUCTORSID WHERE COURSEINSTRUCTOR.COURSESID = {model.Course.Id}").ToList();
                    model.StudentCourses = _context.StudentCourses.FromSqlInterpolated($"SELECT * FROM STUDENTCOURSES WHERE COURSEID = {model.Course.Id} AND STUDENTID = {Id}").ToList();
                }

                viewModel.Add(model);
            }

            return viewModel;
        }
    }
}
