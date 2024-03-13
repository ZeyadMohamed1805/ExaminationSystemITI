using ExaminationSystemITI.Abstractions.Enums;
using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ExaminationSystemITI.Services
{
    public class ChoiceService : IChoiceService
    {
        ApplicationDbContext _db;
        //--------------------------------------------------------------------------
        public ChoiceService(ApplicationDbContext db)
        {
            _db = db;
        }
        //--------------------------------------------------------------------------
        public List<Choice> GetAll()
        {
            return _db.Choices.FromSqlInterpolated($"GetAllChoices").ToList();
        }
        //--------------------------------------------------------------------------
        public List<Choice> GetAllInQuestion(int questionId)
        {
            return _db.Choices.FromSqlInterpolated($"GetAllChoicesInQuestion {questionId}").ToList();
        }
        //--------------------------------------------------------------------------

        public void Add(Choice choice)
        {
            _db.Database.ExecuteSqlInterpolated($"AddChoice {choice.Text},{choice.Id}");
        }
        //--------------------------------------------------------------------------

        public void Delete(Choice choice)
        {
            _db.Database.ExecuteSqlInterpolated($"DeleteChoice {choice.Text},{choice.Id}");
        }
        //--------------------------------------------------------------------------

        public void Update(Choice choice,string newChoiceText)
        {
            _db.Database.ExecuteSqlInterpolated($"UpdateChoice {choice.Text},{newChoiceText},{choice.Id} ");
        }
    }
}
