using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class CourseController : Controller
    {
        ICourseService _course;
        IDepartmentService _department;
        IStudentService _student;
        public CourseController( ICourseService course, IDepartmentService department, IStudentService student )
        {
            _course = course;
            _department = department;
            _student = student;
        }
        public IActionResult Read()
        {
            var courses = _course.GetCourses();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _department.GetDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseDepartmentsViewModel viewModel)
        {
            _course.InsertCourse(viewModel.Course);
            viewModel.Course = _course.GetCourses().SingleOrDefault(course => course.Name == viewModel.Course.Name);
            _course.InsertCourseDepartments(viewModel);
            return RedirectToAction("Read");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _course.FindCourse(id);
            return View(course);
        }
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            _course.EditCourse(course);
            return RedirectToAction("Read");
        }
        public IActionResult Delete(int id)
        {
            _course.DeleteCourse(id);
            return RedirectToAction("Read");
        }
    }
}
