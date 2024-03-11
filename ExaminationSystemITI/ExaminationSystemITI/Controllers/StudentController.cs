using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class StudentController : Controller
    {
 

        IStudentService _student;
        
        public StudentController(IStudentService student) 
        {
            _student = student;
        
        }
        public IActionResult Index()
        {
            var students = _student.GetAll();
            return View(students);
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
