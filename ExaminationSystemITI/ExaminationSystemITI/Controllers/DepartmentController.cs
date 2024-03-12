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

        public IActionResult GetDep()
        {
            var departments = _department.GetDepartments();
            return View(departments);
        }
        [HttpGet]
        public IActionResult AddDep()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDep(Department department)
        {
            _department.InsertDepartment(department);
            return RedirectToAction("GetDep");
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
            return RedirectToAction("GetDep");
        }

        [HttpPost]
        public IActionResult Delete(Department dep)
        {
            _department.DeleteDepartment(dep.Id);
            return RedirectToAction("GetDep");
        }


    }
}
