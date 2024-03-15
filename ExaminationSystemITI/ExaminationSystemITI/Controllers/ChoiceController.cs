using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
using ExaminationSystemITI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace ExaminationSystemITI.Controllers
{
    public class ChoiceController : Controller
    {
        IChoiceService _choice;
        public ChoiceController(IChoiceService choice)
        {
            _choice = choice;
        }
        public IActionResult Read()
        {
            var choices = _choice.GetAll();
            return View(choices);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Choice choice)
        {
            _choice.Add(choice);
            return RedirectToAction("Read");
        }

        [HttpGet]
        public IActionResult Edit(int id, string text)
        {
            return View(new Choice() { Id = id, Text = text });
        }

        [HttpPost]
        public IActionResult Edit(Choice choice, string newText)
        {
            _choice.Update(choice, newText);
            return RedirectToAction("Read");
        }
        public IActionResult Delete(int id, string text)
        {
            _choice.Delete(new Choice() { Id = id, Text = text });
            return RedirectToAction("Read");
        }
    }
}
