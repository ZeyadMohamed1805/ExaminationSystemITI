using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Controllers
{
    public class ExamController : Controller
    {
        ApplicationDbContext _dbcontext;
        public ExamController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Getall()
        {
            //var Exams = _dbcontext.Exams.ToList();
            var Exams = _dbcontext.Exams.Include(e => e.Course).ToList();
            return View(Exams);
        }

        public IActionResult Course(int Id)
        {
            return View();
        } 

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _dbcontext.Courses.ToList();
            ViewBag.Questions = _dbcontext.Questions.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Exam exam)
        {
            
            var courseQuestions = _dbcontext.Questions.Where(q => q.CourseId == exam.CourseID).ToList();

            
            var random = new Random();
            var RandomQuestions = courseQuestions.OrderBy(q => random.Next()).ToList();

            
            var selectedQuestions = RandomQuestions.Take(exam.QCount).ToList();

            
            _dbcontext.Exams.Add(exam);
            _dbcontext.SaveChanges();

            // Insert selected questions into ExamQuestion table
            foreach (var question in selectedQuestions)
            {
                //_dbcontext.ExamQuestion.Add(new ExamQuestion { ExamId = exam.ID, QuestionId = question.Id });
                _dbcontext.Database.ExecuteSqlInterpolated($"Exec InsertExamQuestion {exam.ID},{question.Id}");
            }
           // _dbcontext.SaveChanges();

            return RedirectToAction("Getall","Exam");
           
        }


        [Route("Exam/Display/{ExamId}")] 
        public IActionResult Display(int ExamId)
        {          
            var questions = _dbcontext.Questions
                .FromSqlRaw("SELECT q.Id, q.Title, q.CorrectAnswer, q.Type, q.CourseId FROM questions q INNER JOIN ExamQuestion eq ON q.Id = eq.QuestionsId WHERE eq.ExamsId = {0} ORDER BY NEWID()", ExamId)
                .ToList();

            return View(questions);
        }
    }
}
