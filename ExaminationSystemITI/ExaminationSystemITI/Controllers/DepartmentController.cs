using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService _department;
        IInstructorService _instructor;
        public DepartmentController(IDepartmentService department, IInstructorService instructor)
        {
            _department = department;
            _instructor = instructor;
        }

        public IActionResult Read()
        {
            ViewBag.Supervisors = _instructor.GetInstructors();
            var departments = _department.GetDepartments();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Supervisors = _instructor.GetActiveSupervisors();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _department.InsertDepartment(department);
            return RedirectToAction("Read");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _department.FindDepartment(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department dep)
        {
            _department.EditDepartment(dep);
            return RedirectToAction("Read");
        }

 
        public IActionResult Delete(int id)
        {
            _department.DeleteDepartment(id);
             return RedirectToAction("Read");

        }


    }
}
