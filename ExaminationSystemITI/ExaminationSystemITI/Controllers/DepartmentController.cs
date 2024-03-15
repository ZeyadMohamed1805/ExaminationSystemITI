using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService _department;
        public DepartmentController(IDepartmentService department)
        { 
           _department = department;
        }

        public IActionResult Read()
        {
            var departments = _department.GetDepartments();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
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
