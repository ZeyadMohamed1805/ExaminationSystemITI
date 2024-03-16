using ExaminationSystemITI.Abstractions.Enums;
using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Authorization;
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

        public StudentController(ApplicationDbContext context , IStudentService student)
        {
            _context = context;
            _student = student;
        }
        public IActionResult Active(int Id)
        {
            return View("Index");
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


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _student.Add(student);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student=_student.GetById(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _student.Update(student);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _student.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
