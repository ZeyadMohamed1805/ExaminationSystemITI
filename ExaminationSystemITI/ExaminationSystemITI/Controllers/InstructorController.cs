using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExaminationSystemITI.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorService _instructor;
        
        public InstructorController(IInstructorService instructor)
        {
            _instructor = instructor;
        }

        public IActionResult Index(int Id)
        {
            return View();
        }
        

        public IActionResult Read()
        {
            var instructors = _instructor.GetInstructors();
            return View(instructors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            _instructor.InsertInstructor(instructor);
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
