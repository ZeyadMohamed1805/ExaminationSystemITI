using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Abstractions.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ExaminationSystemITI.Abstractions.Interfaces;

namespace ExaminationSystemITI.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;
        IQuestionInterface _questionService;
        ICourseService _courseService;
        public QuestionController(ApplicationDbContext context,IQuestionInterface questionService,ICourseService courseService)
        {
            _context = context;
            _questionService = questionService;
            _courseService = courseService;
        }


        public IActionResult Read()
        {
            var questions=_questionService.GetQuestions();
           
            return View(questions);
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
                        var choice = new Choice { Text = choiceText, Id = question.Id };
                        _context.Choices.Add(choice);
                    }
                    _context.SaveChanges();
                }
            return RedirectToAction("Read");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var question=_questionService.FindQuestion(id);
            return View(question);
        }
        [HttpPost]
        public IActionResult Edit(Question question)
        {
            _questionService.Update(question);
            return RedirectToAction("Read");
        }
        public IActionResult Delete(int id)
        {
           _questionService.DeleteQuestion(id);   
            return RedirectToAction("Read");
        }
    }
}
