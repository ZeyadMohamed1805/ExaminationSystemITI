using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
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
        public IActionResult Read()
        {
            var courses = _course.GetCourses();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            _course.InsertCourse(course);
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
