using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index(int Id)
        {
            return View();
        }
    }
}
