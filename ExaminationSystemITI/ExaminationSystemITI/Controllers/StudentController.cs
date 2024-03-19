using ExaminationSystemITI.Abstractions.Enums;
using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Authorization;
using ExaminationSystemITI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace ExaminationSystemITI.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        IStudentService _student;
        IDepartmentService _department;
        ICourseService _course;
        IInstructorService _instructor;
        IExamService _exam;

        public StudentController(ApplicationDbContext context , IStudentService student, IDepartmentService department, ICourseService course, IInstructorService instructor, IExamService exam)
        {
            _context = context;
            _student = student;
            _department = department;
            _course = course;
            _instructor = instructor;
            _exam = exam;
        }

        public void GetData()
        {
            
        }
        
        public IActionResult Index()
        {

            if (User.IsInRole(ERole.Student.ToString()))
            {

                var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;


                var students = _student.GetAll().Where(s => s.Email == userEmail).AsQueryable().Include(s => s.StudentCourses).ThenInclude(c => c.Course);

                

                ////string studentEmail = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;
                ////Debug.WriteLine("User Email: " + studentEmail);
                ////Debug.WriteLine("asasa");
                //////ViewBag.Email = studentEmail;

                
                return View(students.ToList());
            }
            else
            {
                // For other roles get all students
                var students = _student.GetAll().AsQueryable().Include(s => s.StudentCourses).ThenInclude(c=>c.Course);
                return View(students.ToList());
            }
        }

        public IActionResult Read()
        {
            var studentCourses = new List<StudentCoursesViewModel>();
            var students = _student.GetAll();

            foreach (var student in students)
                studentCourses.Add(
                    new StudentCoursesViewModel()
                    {
                        Student = student,
                        Courses = _student.GetStudentCourses(student.Id)
                    }
                );

            return View(studentCourses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new StudentDepartmentsViewModel();
            ViewBag.Departments = _department.GetDepartments();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _student.Add(student);

            return RedirectToAction("Read");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new StudentDepartmentsViewModel();
            viewModel.Student = _student.GetById(id);
            ViewBag.Departments = _department.GetDepartments();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(StudentDepartmentsViewModel viewModel)
        {
            _student.Update(viewModel.Student);
            return RedirectToAction("Read");
        }

        public IActionResult Delete(int id)
        {
            _student.Delete(id);
            return RedirectToAction("Read");
        }

        public IActionResult Exams(int Id)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var students = _student.GetAll().Where(s => s.Email == userEmail).AsQueryable();
            ViewBag.StudentId = students.First().Id;
            ViewBag.StudentName = students.First().FirstName;
            var viewModel = _course.FindStudentActiveExams(Id);
            return View(viewModel);
        }

        public IActionResult Done(int Id)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var students = _student.GetAll().Where(s => s.Email == userEmail).AsQueryable();
            ViewBag.StudentId = students.First().Id;
            ViewBag.StudentName = students.First().FirstName;
            var viewModel = _course.FindStudentDoneExams(Id);
            return View(viewModel);
        }
    }
}
