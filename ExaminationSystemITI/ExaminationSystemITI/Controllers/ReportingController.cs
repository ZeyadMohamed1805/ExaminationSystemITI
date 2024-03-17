using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Controllers
{
    public class ReportingController : Controller
    {
        ApplicationDbContext _dbContext;
        public ReportingController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        [HttpGet]
        public IActionResult StudentsByDepartment()
        {

            var departments = _dbContext.Departments.ToList();

            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        [Route("Reporting/StudentsByDepartment/{Id}")]
        public IActionResult StudentsByDepartment(int Id)
        {

            var students = _dbContext.Students.FromSqlRaw("EXECUTE dbo.GetAllStudentsByDepartmentId @DepartmentId", new SqlParameter("@DepartmentId", Id)).ToList();

            return View();
        }

    }
}
