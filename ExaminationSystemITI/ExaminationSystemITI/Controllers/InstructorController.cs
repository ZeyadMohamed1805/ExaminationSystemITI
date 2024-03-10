using ExaminationSystemITI.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorService _instructor;
        public InstructorController(IInstructorService instructor)
        {
            _instructor = instructor;
        }
        public IActionResult GetIns()
        {
            var instructors = _instructor.GetInstructors();
            return View(instructors);
        }
    }
}
