using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Services
{
    public class QuestionService : IQuestionInterface
    {
        ApplicationDbContext _dbcontext;
        public QuestionService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Question> GetQuestions()
        {
            var questions = _dbcontext.Questions.Include(a=>a.Course).ToList();

            return questions;
        }

        public void DeleteQuestion(int Id)
        {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC DeleteQuestionById {Id}");
        }

        public Question FindQuestion(int id)
        {
            var question = _dbcontext.Questions.Find(id);
            return question;
        }

        public void Update(Question question)
        {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC EditQuestionsById {question.Id},{question.Type},{question.Title},{question.CorrectAnswer}");
        }
    }
}
