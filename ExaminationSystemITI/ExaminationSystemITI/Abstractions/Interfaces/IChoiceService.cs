using ExaminationSystemITI.Abstractions.Enums;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Services;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface IChoiceService
    {
        List<Choice> GetAll(); 
        List<Choice> GetAllInQuestion(int questionId); //gets all choices in a question
        void Add(Choice choice);
        void Delete(Choice choice);
        void Update(Choice choice, string newChoiceText);
        public Choice? FindChoice(Choice choice);
    }
}
