using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace ExaminationSystemITI.Controllers
{
    public class ChoiceController : Controller
    {
        IChoiceService _choiceService;
        public ChoiceController(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }
        //--------------------------------------------------------------------------
        public IActionResult Index()
        {
            var choices = _choiceService.GetAll();
            return View(choices);
        }
        //--------------------------------------------------------------------------
        public IActionResult Read(int id)
        {
            var choices = _choiceService.GetAllInQuestion(id);
            return View(choices);
        }
        //--------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            Choice choice = new Choice();
            return View(choice);
        }
        [HttpPost]
        public IActionResult Create(Choice choice)
        {
            _choiceService.Add(choice);
            return RedirectToAction("Index");
        }
        //--------------------------------------------------------------------------
        public IActionResult Update(Choice model)
        {
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Choice choice, string newText)
        {
            _choiceService.Update(choice, newText);
            return RedirectToAction("Index");
        }
        //--------------------------------------------------------------------------
        public IActionResult Delete(Choice choice)
        {
            _choiceService.Delete(choice);
            return RedirectToAction("Index");
        }
    }
}
