using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class CourseController : Controller
    {
        ICourseService _course;
        public CourseController( ICourseService course )
        {
            _course = course;
        }
        public IActionResult Index()
        {
            ICollection<Course> courses = _course.GetCourses();
            return View(courses);
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            _course.InsertCourse(course);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Course course)
        {
            _course.DeleteCourse(course.Id);
            return RedirectToAction("Index");
        }
    }
}
