using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface IQuestionInterface
    {
        public List<Question> GetQuestions();

        public void DeleteQuestion(int Id);

        public Question FindQuestion(int id);
    }
}
