using ExaminationSystemITI.Abstractions.Enums;
using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Services
{
    public class ChoiceService : IChoiceService
    {
        ApplicationDbContext _dbContext;
        //--------------------------------------------------------------------------
        public ChoiceService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //--------------------------------------------------------------------------
        public List<Choice> GetAll()
        {
            return _dbContext.Choices.FromSqlInterpolated($"GetAllChoices").ToList();
        }
        //--------------------------------------------------------------------------
        public List<Choice> GetAllInQuestion(int questionId)
        {
            return _dbContext.Choices.FromSqlInterpolated($"GetAllChoicesInQuestion {questionId}").ToList();
        }
        //--------------------------------------------------------------------------

        public void Add(Choice choice)
        {
            _dbContext.Database.ExecuteSqlInterpolated($"AddChoice {choice.Text},{choice.Id}");
        }
        //--------------------------------------------------------------------------

        public void Delete(Choice choice)
        {
            _dbContext.Database.ExecuteSqlInterpolated($"DeleteChoice {choice.Text},{choice.Id}");
        }
        //--------------------------------------------------------------------------

        public void Update(Choice choice,string newChoiceText)
        {
            _dbContext.Database.ExecuteSqlInterpolated($"UpdateChoice {choice.Text},{newChoiceText},{choice.Id} ");
        }

        public Choice? FindChoice(Choice choice)
        {
            var Choice = _dbContext.Choices.FromSqlInterpolated($"SELECT * FROM CHOICES WHERE ID = {choice.Id} AND TEXT = {choice.Text}").ToList()[0];
            return Choice;
        }
    }
}
