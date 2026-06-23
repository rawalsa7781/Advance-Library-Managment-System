using LibraryPro1.Data;
using LibraryPro1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryPro1.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryDbContext _context;

        public AccountController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _context.Admins
                .FirstOrDefault(x =>
                    x.Username == username &&
                    x.Password == password);

            if (admin != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Invalid Username or Password";

            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}