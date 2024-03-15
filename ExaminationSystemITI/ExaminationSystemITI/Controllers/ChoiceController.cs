using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
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
        public IActionResult Edit(int Qid, string text)
        {
            var choice = _choice.FindChoice(new Choice() { Id = Qid, Text = text });
            var viewModel = new ChoiceViewModel();
            viewModel.Choice.Id = Qid;
            viewModel.Choice.Text = text;
            viewModel.NewText = "";
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ChoiceViewModel viewModel)
        {
            _choice.Update(new Choice() { Id = viewModel.Choice.Id, Text = viewModel.Choice.Text }, viewModel.NewText);
            return View();
        }
        public IActionResult Delete(int Qid, string text)
        {
            _choice.Delete(new Choice() { Id = Qid, Text = text });
            return RedirectToAction("Read");
        }
    }
}
