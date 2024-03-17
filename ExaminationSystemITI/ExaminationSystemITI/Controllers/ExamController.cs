
using ExaminationSystemITI.Abstractions.Enums;
using Microsoft.AspNetCore.Authorization;
using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
using ExaminationSystemITI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace ExaminationSystemITI.Controllers
{
    [Authorize]
    public class ExamController : Controller
    {
        ApplicationDbContext _dbcontext;
        IExamService _examService;
        ICourseService _courseService;
        IQuestionInterface _QuestionServices;
        public ExamController(ApplicationDbContext dbcontext, IExamService examService, ICourseService courseService, IQuestionInterface questionServices)
        {
            _dbcontext = dbcontext;
            _examService = examService;
            _courseService = courseService;
            _QuestionServices = questionServices;
        }

        public IActionResult Read(int Id)
        {
            if (User.IsInRole(ERole.Student.ToString()))
            {
                string studentEmail = User.FindFirst(ClaimTypes.Email)?.Value;

                
                var student = _dbcontext.Students
                    .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                    .FirstOrDefault(s => s.Email == studentEmail);
                
                int studentId = student.Id;

                if (student == null)
                {
                    
                    return NotFound();
                }

                
                var courseIds = student.StudentCourses.Select(sc => sc.CourseId);

               
                var exams = _dbcontext.Exams
                    .Where(e => courseIds.Contains(e.CourseID) && !_dbcontext.StudentExamQuestions.Any(seq => seq.StudentId == studentId && seq.ExamId == e.ID))
                    .Include(e => e.Course)
                    .ToList();

                return View(exams);
            }
            else
            {
                var Exams = _dbcontext.Exams.Include(e => e.Course).ToList();
                return View(Exams);
            }
           
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

            return RedirectToAction("Read", "Exam");
           
        }


        [Route("Exam/Display/{ExamId}")]
        [Authorize]
        public IActionResult Display(int ExamId)
        {
            //var questions = _dbcontext.Questions
            //    .FromSqlRaw("SELECT q.Id, q.Title, q.CorrectAnswer, q.Type, q.CourseId FROM questions q INNER JOIN ExamQuestion eq ON q.Id = eq.QuestionsId WHERE eq.ExamsId = {0} ORDER BY NEWID()", ExamId)
            //    .Include(a=>a.Choices)
            //    .ToList();

            //return View(questions);

            var questions = _dbcontext.Questions
               .FromSqlRaw("SELECT q.Id, q.Title, q.CorrectAnswer, q.Type, q.CourseId FROM questions q INNER JOIN ExamQuestion eq ON q.Id = eq.QuestionsId WHERE eq.ExamsId = {0}", ExamId)
               .Include(a => a.Choices)
               .ToList();
            
            string studentEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            Debug.WriteLine("User Email: " + studentEmail);
            Debug.WriteLine("asasa");
            ViewBag.Email = studentEmail;
            ViewBag.ExamId = ExamId;
            return View(questions);
        }


        [HttpPost]
        public IActionResult SubmitAnswers(SubmitAnswersViewModel model , string StudentEmail , int courseId , int ExamId)
        {

            var student = _dbcontext.Students.FirstOrDefault(s => s.Email == StudentEmail);
            int studentId = student.Id;
            var studentCourse = _dbcontext.StudentCourses
                 .FirstOrDefault(sc => sc.StudentId == student.Id && sc.CourseId == courseId);
            var submittedQuestionIds = model.Answers.Select(a => a.QuestionId).ToList();

            
            var correctAnswers = _dbcontext.Questions
                .Where(q => submittedQuestionIds.Contains(q.Id))
                .ToDictionary(q => q.Id, q => q.CorrectAnswer);

            // Retrieve correct answers from the database
            //var correctAnswers = _dbcontext.Questions.ToDictionary(q => q.Id, q => q.CorrectAnswer);


            int totalQuestions = model.Answers.Count;
            int correctCount = 0;
            foreach (var answer in model.Answers)
            {
                if (correctAnswers.TryGetValue(answer.QuestionId, out var correctAnswer) && correctAnswer == answer.Answer)
                {
                    correctCount++;
                }
            }

            
            double percentage = (double)correctCount / totalQuestions * 100;

            
            ViewBag.CorrectCount = correctCount;
            ViewBag.TotalQuestions = totalQuestions;
            ViewBag.Percentage = percentage;

            studentCourse.Grade = percentage;

            foreach (var answer in model.Answers)
            {
                var studentExamQuestion = new StudentExamQuestion
                {
                    StudentId = student.Id,
                    ExamId = ExamId, 
                    QuestionId = answer.QuestionId,
                    Answer = answer.Answer
                };

                _dbcontext.StudentExamQuestions.Add(studentExamQuestion);
            }


            _dbcontext.SaveChanges();

            return View("SubmitAnswers");
        }

        [Route("Exam/DisplayAnsweredExams/{studentId}")]
        public IActionResult DisplayAnsweredExams(int studentId)
        {
            var examsWithGrades = _dbcontext.StudentExamQuestions
                .Where(seq => seq.StudentId == studentId)
                .Select(seq => new StudentExamViewModel
                {
                    ExamId = seq.ExamId,
                    ExamName = _dbcontext.Courses.FirstOrDefault(c => c.Id == seq.Exam.CourseID).Name,
                    Grade = _dbcontext.StudentCourses.FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == seq.Exam.CourseID).Grade
                })
                .Distinct()
                .ToList();
            return View(examsWithGrades);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new ExamCourseQuestionViewModel();

            viewModel.Exam = _examService.FindExam(id);
            ViewBag.Courses = _courseService.GetCourses();
            ViewBag.Questions = _QuestionServices.GetQuestions();
            return View(viewModel);

        }
        
        [HttpPost]
        public IActionResult Edit(ExamCourseQuestionViewModel model)
        {
            _examService.Update(model.Exam);
            return RedirectToAction("Read");
        }

        public IActionResult Delete(int id)
        {
            _examService.DeleteExam(id);
            return RedirectToAction("Read");
        }
    }
}
