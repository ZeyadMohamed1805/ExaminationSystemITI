using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExaminationSystemITI.Services
{
    public class ExamService : IExamService
    {
        
            ApplicationDbContext _dbcontext;
            public ExamService(ApplicationDbContext dbcontext)
            {
                _dbcontext = dbcontext;
            }

            public List<Exam> GetExams()
            {
                var exams = _dbcontext.Exams.ToList();
                return exams;
            }

            public void DeleteExam(int Id)
            {
                _dbcontext.Database.ExecuteSqlInterpolated($"EXEC DeleteExamById {Id}");
            }

            public Exam FindExam(int id)
            {
                var exam = _dbcontext.Exams.Find(id);
                return exam;
            }

            public void Update(Exam exam)
            {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC EditExamById {exam.ID},{exam.Duration},{exam.Date},{exam.QCount},{exam.TotalMarks}");
            //_dbcontext.Database.ExecuteSqlInterpolated($"EXEC EditExamById {exam.ID},{exam.Duration},{exam.Questions.Count},{exam.TotalMarks}");
        }
    }
}
