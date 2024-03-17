using ExaminationSystemITI.Abstractions.Enums;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace ExaminationSystemITI.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDbContext _dbcontext;
        public AccountController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            //⬇⬇⬇
            var res = _dbcontext.Users.Include(a => a.Roles).FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
            //check in db
            if (res == null)
            {
                ModelState.AddModelError("", "username and password invalid");
                return View(model);
            }
           
            Claim c1 = new Claim(ClaimTypes.Email, res.Email);
            List<Claim> Roleclaims = new List<Claim>();//
            foreach (var item in res.Roles)
            {
                Roleclaims.Add(new Claim(ClaimTypes.Role, item.Description.ToString()));
            }

            ClaimsIdentity ci = new ClaimsIdentity("Cookies");
            ci.AddClaim(c1);
            foreach (var item in Roleclaims)
            {
                ci.AddClaim(item);
            }
            
            ClaimsPrincipal cp = new ClaimsPrincipal();
            cp.AddIdentity(ci);
            //
            await HttpContext.SignInAsync(cp);
            Debug.WriteLine($"Email: {HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value}");
            if (res.Roles.Any(r => r.Description.ToString() == "Admin"))
            {
                return RedirectToAction("Read", "Student");
            }
            else if (res.Roles.Any(r => r.Description.ToString() == "Instructor"))
            {
                return RedirectToAction("Read", "Question");
            }
            else 
            {
                var userEmail = res.Email;
                var students = _dbcontext.Students.Where(s => s.Email == userEmail).AsQueryable().ToList();
                return RedirectToAction("Exams", "Student", new { Id = students.First().Id });
            }
           
        }
        [HttpGet]
        [Authorize]
        public IActionResult Info()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email).Value;
            if (User.IsInRole(ERole.Student.ToString()))
            {
                var student = _dbcontext.Students.FirstOrDefault(a => a.Email == userEmail);
                return View(student);
            }
            else if (User.IsInRole(ERole.Instructor.ToString())) {
                var instructor = _dbcontext.Instructors.FirstOrDefault(a => a.Email == userEmail);
                return View(instructor);
            }
            else
            {
                var admin = _dbcontext.Admins.FirstOrDefault(a => a.Email == userEmail);
                return View(admin);
            }
            
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
