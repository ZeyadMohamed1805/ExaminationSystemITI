using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Abstractions.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSystemITI.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _context.Courses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Question question, string[] choices)
        {
            //if (ModelState.IsValid)
            //{
                
                _context.Questions.Add(question);
                _context.SaveChanges();

               
                var course =  _context.Courses.Find(question.CourseId);
                if (course != null)
                {
                    course.Questions.Add(question);
                    _context.SaveChanges();
                }

              
                if (question.Type == EQuestionType.MCQ && choices != null)
                {
                    foreach (var choiceText in choices)
                    {
                        var choice = new Choice { Text = choiceText, QuestionId = question.Id };
                        _context.Choices.Add(choice);
                    }
                    _context.SaveChanges();
                }

                return RedirectToAction("Getall", "Exam"); 
           // }

            
            //ViewBag.Courses = _context.Courses.ToList();
            //return View(question);
        }
    }
}
