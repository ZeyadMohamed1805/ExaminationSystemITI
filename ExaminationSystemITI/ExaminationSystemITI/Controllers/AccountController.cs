using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (res.Roles.Any(r => r.Description.ToString() == "Admin"))
            {
                return RedirectToAction("Index", "Student");
            }
            else if (res.Roles.Any(r => r.Description.ToString() == "Instructor"))
            {
                return RedirectToAction("Index", "Student");
            }
            else 
            {
                return RedirectToAction("Index", "Student");
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
