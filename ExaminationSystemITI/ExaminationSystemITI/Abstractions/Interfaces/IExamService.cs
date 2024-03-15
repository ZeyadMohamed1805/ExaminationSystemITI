using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface IExamService
    {

        public List<Exam> GetExams();

        public void Update(Exam exam);
        public void DeleteExam(int Id);

        public Exam FindExam(int id);
    }
}
