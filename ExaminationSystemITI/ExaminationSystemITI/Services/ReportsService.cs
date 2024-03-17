using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace ExaminationSystemITI.Services
{
    public class ReportsService
    {
        ApplicationDbContext _db;
        //--------------------------------------------------------------------------
        public ReportsService(ApplicationDbContext db)
        {
            _db = db;
        }
        //--------------------------------------------------------------------------
        public List<Topic> GetAllTopicsByCourseId(int courseId)
        {
            List<Topic> model = _db.Topics.FromSqlInterpolated($"GetAllTopicsByCourseId {courseId}").ToList();
            return model;
        }
        //--------------------------------------------------------------------------

        //public ReportViewModel GetAllCoursesAndStudentsByInstructorId(int InstructorId)
        //{
        //    //ReportViewModel reportViewModel = new ReportViewModel();
        //    var model = _db.Instructors.FromSqlInterpolated($"GetAllCoursesAndStudentsByInstructorId {InstructorId}");
        //    return model;
        //}

    }
}
