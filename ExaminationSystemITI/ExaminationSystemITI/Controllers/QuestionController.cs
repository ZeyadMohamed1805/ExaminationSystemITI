using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Abstractions.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.ViewModels;
using System.Security.Claims;

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
            if (User.IsInRole(ERole.Instructor.ToString()))
            {
                string insEmail = User.FindFirst(ClaimTypes.Email)?.Value;
                var model = new questioncourses();


                var questions = _context.Questions.FromSqlInterpolated($"SELECT\r\n    e.*\r\nFROM\r\n    QUESTIONS e\r\nJOIN\r\n    Courses c ON e.CourseID = c.ID\r\nJOIN\r\n    CourseInstructor ic ON c.ID = ic.CoursesID\r\nJOIN\r\n    Instructors i ON ic.InstructorsID = i.ID\r\nWHERE\r\n    i.Email = {insEmail};\r\n").ToList();
                var course = _context.Courses.FromSqlInterpolated($"SELECT C.* FROM COURSES C JOIN Courseinstructor I ON C.ID=I.CoursesId JOIN INSTRUCTORS INS ON INS.EMAIL ={insEmail}").ToList();
                model.Questions = questions;
                model.Courses = course;
                return View(model);
            }
            else
            {
                var questions = _questionService.GetQuestions();
                var model = new questioncourses();
                model.Questions = questions;
                return View(model);
            }
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            string insEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            Instructor instructor = _context.Instructors.FromSqlInterpolated($"SELECT * FROM INSTRUCTORS WHERE EMAIL = {insEmail}").ToList()[0];
            ViewBag.insCourses = _context.Courses.FromSqlInterpolated($"SELECT * FROM COURSES JOIN COURSEINSTRUCTOR ON COURSES.ID = COURSEINSTRUCTOR.COURSESID WHERE COURSEINSTRUCTOR.INSTRUCTORSID = {instructor.ID}").ToList();
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
