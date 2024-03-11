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
        public ChoiceService(ApplicationDbContext db)
        {
            _db = db;
        }

        #region StoredProcedures
         //create proc GetAllChoices @QId int
         //as
         //select* from Choices where QuestionId=@QId

         //--GetAllChoices 1
         //----------------------------------------------------------------
         //go
         //create proc AddChoice @text nvarchar(450)  , @Qid int
         //as
         //insert into Choices values(@text, @Qid)

         //--AddChoice 'kkk',2
         //----------------------------------------------------------------
         //go
         //create proc DeleteChoice @text nvarchar(450) , @Qid int
         //as
         //delete from Choices where Text=@text and QuestionId=@Qid

         //--DeleteChoice 'kkk',2
         //----------------------------------------------------------------
         //go
         //create proc UpdateChoice @textOld nvarchar(450), @textNew nvarchar(450) , @Qid int
         //as 
         //update Choices
         //set Text = @textNew
         //where QuestionId = @Qid and Text = @textOld

         //--updatechoice aaaa, ddddd,2
         //---------------------------------------------------------------- 
         #endregion

        public List<Choice> GetAll(int questionId)
        {
            return _db.Choices.FromSqlInterpolated($"GetAllChoices {questionId}").ToList();
        }

        public void Add(Choice choice)
        {
            _db.Choices.FromSqlInterpolated($"AddChoice '{choice.Text}',{choice.QuestionId}");
        }

        public void Delete(Choice choice)
        {
            _db.Choices.FromSqlInterpolated($"DeleteChoice '{choice.Text}',{choice.QuestionId}");
        }

        public void Update(Choice choice,string newChoiceText)
        {
            _db.Choices.FromSqlInterpolated($"UpdateChoice '{choice.Text}','{newChoiceText}',{choice.QuestionId} ");
        }
    }
}
