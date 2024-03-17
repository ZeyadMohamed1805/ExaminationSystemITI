using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
using System.Security.Policy;
using System.Configuration;
using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Services;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Database;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ReportsService _reportsService;
        private readonly ApplicationDbContext _db;
        public ReportsController( ApplicationDbContext db)
        {
            _reportsService = new ReportsService(db);
            _db = db;
        }
        //-----------------------------------------
        public IActionResult Index()
        {
            return View();
        }
        //-------------------------------
        //public IActionResult GetAllCoursesAndStudentsByInstructorId()
        //{
        //    return View();
        //}
        //-------------------------------
        public IActionResult GetAllCoursesAndStudentsByInstructorId(int InstructorId)
        { 
            //ReportViewModel reportViewModel = new ReportViewModel();
            var model = _db.Instructors.FromSqlInterpolated($"GetAllCoursesAndStudentsByInstructorId {InstructorId}").ToList();
            return View(model);
        }
        //-------------------------------
        public IActionResult GetAllCoursesGradesByStudentId()
        {
            return View();
        }
        //-------------------------------
        public IActionResult GetAllCoursesGradesByStudentId(int StudentId)
        {
            return View();
        }
        //-------------------------------
        public IActionResult GetAllQuestionsAndChoicesByExamId()
        {
            return View();
        }
        //-------------------------------
        public IActionResult GetAllQuestionsAndChoicesByExamId(int ExamId)
        {
            return View();
        }
        //-------------------------------
        public IActionResult GetAllQuestionsAndStudentAnswerByExamIdAndStudentId()
        {
            return View();
        }
        //-------------------------------
        public IActionResult GetAllQuestionsAndStudentAnswerByExamIdAndStudentId(int ExamId, int StudentId)
        {
            return View();
        }
        //-------------------------------
        //public IActionResult GetAllTopicsByCourseId()
        //{
        //    return View();
        //}
        //-------------------------------
        //public IActionResult GetAllTopicsByCourseId(int CourseId)
        //{
        //    List<Topic> model = _db.Topics.FromSqlInterpolated($"GetAllTopicsByCourseId {CourseId}").ToList();
        //    return View(model);
        //}
        //-------------------------------
        public IActionResult ReportGetAllStudentsByDepartmentId()
        {
            return View();
        }
        //-------------------------------
        public IActionResult ReportGetAllStudentsByDepartmentId(int DepartmentId)
        {
            return View();
        }
        //-------------------------------


        #region MyRegion

        //public IActionResult Index()
        //{
        //    string ssrsURL = System.Configuration.ConfigurationManager.AppSettings["SSRSReportsURL"].ToString();

        //    ReportViewer viewer = new ReportViewer();
        //    viewer.ProcessingMode = ProcessingMode.Remote;
        //    viewer.SizeToReportContent = true;
        //    viewer.AsyncRendering = true;
        //    viewer.ServerReport.ReportServerUrl = new Uri(ssrsURL);
        //    viewer.ServerReport.ReportPath = "/AllChoicesReport";

        //    ViewBag.ReportViewer = viewer;

        //    return View();
        //}


        //public IActionResult Show(int id)
        //{
        //    ViewBag.id = id;
        //    return View();
        //}


        //public ActionResult DisplayReport(int instructorId)
        //{
        //    // Retrieve InstructorID from the model (example)
        //    //int instructorId = ViewBag.Instructor.ID;
        //    ViewBag.Instructor.ID = instructorId;

        //    // Set parameters
        //    ReportParameter[] parameters = new ReportParameter[1];
        //    parameters[0] = new ReportParameter("InstructorID", instructorId.ToString());

        //    ViewBag.Parameters = parameters;

        //    return View();
        //} 
        #endregion
    }
}
