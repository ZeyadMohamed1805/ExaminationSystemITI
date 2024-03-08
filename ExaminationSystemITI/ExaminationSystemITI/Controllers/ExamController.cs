using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult Course(int Id)
        {
            return View();
        }
    }
}
