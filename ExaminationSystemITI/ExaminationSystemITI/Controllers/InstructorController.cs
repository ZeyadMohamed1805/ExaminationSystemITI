using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;

namespace ExaminationSystemITI.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorService _instructor;
        ICourseService _course;
        
        public InstructorController(IInstructorService instructor, ICourseService course)
        {
            _instructor = instructor;
            _course = course;
        }

        public IActionResult Index(int Id)
        {
            return View();
        }
        

        public IActionResult Read()
        {
            
            var courseinstructors = new List<InstructorCoursesViewModel>();
            var instructors = _instructor.GetInstructors();

            foreach (var instructor in instructors)
                courseinstructors.Add(
                    new InstructorCoursesViewModel() {
                        Instructor = instructor,
                        Courses = _instructor.GetInstructorCourses(instructor.ID)
                    }
                );

            return View(courseinstructors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _course.GetCourses();
            return View();
        }

        [HttpPost]
        public IActionResult Create(InstructorCoursesViewModel viewModel)
        {
            _instructor.InsertInstructor(viewModel.Instructor);
            viewModel.Instructor = _instructor.GetInstructors().SingleOrDefault( instructor => instructor.Email == viewModel.Instructor.Email );
            _instructor.InsertInstructorCourses(viewModel);
            return RedirectToAction("Read");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var instructor = _instructor.FindInstructor(id);
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(Instructor ins)
        {
            _instructor.EditInstructor(ins);
            return RedirectToAction("Read");
        }

        public IActionResult Delete(Instructor ins)
        {
            _instructor.DeleteInstructor(ins.ID);
            return RedirectToAction("Read");
        }
    }
}
