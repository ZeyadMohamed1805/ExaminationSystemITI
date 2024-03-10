using ExaminationSystemITI.Abstractions.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class ChoiceController : Controller
    {
        IChoiceService _choiceService;
        public ChoiceController(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }

        public ActionResult Index()
        {
            return View();
        }

        
    }
}
