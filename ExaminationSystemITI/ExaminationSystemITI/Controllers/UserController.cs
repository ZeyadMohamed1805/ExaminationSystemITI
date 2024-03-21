using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class UserController : Controller
    {
        IUserService _user;

        public UserController(IUserService user)
        {
            _user = user;
        }

        public IActionResult Index(string email)
        {
            return View();
        }


        public IActionResult Read()
        {
            var users = _user.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _user.InsertUser(user);
            return RedirectToAction("Read");
        }

        [HttpGet]
        public IActionResult Edit(string email)
        {
            var user = _user.FindUser(email);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user, string newEmail)
        {
            _user.EditUser(user, newEmail);
            return RedirectToAction("Read");
        }

        public IActionResult Delete(string email)
        {
            _user.DeleteUser(email);
            return RedirectToAction("Read");
        }
    }
}
