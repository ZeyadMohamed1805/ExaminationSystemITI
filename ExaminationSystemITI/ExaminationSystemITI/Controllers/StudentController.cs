using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Active(int Id)
        {
            return View("Index");
        }
    }
}
