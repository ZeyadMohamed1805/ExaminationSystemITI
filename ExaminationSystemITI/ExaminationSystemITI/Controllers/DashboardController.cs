using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Admin(int Id)
        {
            return View("Dashboard/Admin/Index");
        }
        public IActionResult Student(int Id)
        {
            return View("Student");
        }
        public IActionResult Instructor(int Id)
        {
            return View("Instructor");
        }
    }
}
