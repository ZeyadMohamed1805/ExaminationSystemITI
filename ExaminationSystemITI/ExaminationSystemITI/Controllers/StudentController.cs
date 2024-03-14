using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
using ExaminationSystemITI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class StudentController : Controller
    {
        IStudentService _student;
        IDepartmentService _department;
        ICourseService _course;
        IInstructorService _instructor;
        IExamService _exam;
        public StudentController(IStudentService student, IDepartmentService department, ICourseService course, IInstructorService instructor, IExamService exam)
        {
            _student = student;
            _department = department;
            _course = course;
            _instructor = instructor;
            _exam = exam;
        }
        public IActionResult Read()
        {
            var students = _student.GetAll();
            return View(students);
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
            viewModel.Student =_student.GetById(id);
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
            var viewModel = _course.FindStudentExams(Id);
            return View(viewModel);
        }
    }
}
