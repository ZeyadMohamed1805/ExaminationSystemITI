using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class AdminController : Controller
    {
        IAdminService _admin;
        public AdminController(IAdminService admin)
        {
            _admin = admin;
        }
        public IActionResult Read()
        {
            var admins = _admin.GetAdmins();
            return View(admins);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Admin admin)
        //{
        //    _admin.InsertAdmin(admin);
        //    return RedirectToAction("Read");
        //}

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var admin = _admin.FindAdmin(Id);
            return View(admin);
        }
        [HttpPost]
        public IActionResult Edit(Admin admin)
        {
            _admin.EditAdmin(admin);
            return RedirectToAction("Read");
        }
        public IActionResult Delete(int Id)
        {
            _admin.DeleteAdmin(Id);
            return RedirectToAction("Read");
        }
    }
}
