using Axioms_Satyendra_Singh.Data;
using Axioms_Satyendra_Singh.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Axioms_Satyendra_Singh.Controllers
{
    public class Login_RegisterController : Controller
    {
        private readonly AppDbContext _context;

        public Login_RegisterController(AppDbContext context)
        {
            _context = context;
        }

        // GET Register
        public IActionResult Register()
        {
            return View();
        }

        // POST Register
        [HttpPost]
        public IActionResult Register(User_Login u)
        {
            if (ModelState.IsValid)
            {
                _context.User_Logins.Add(u);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(u);
        }

        // GET Login
        public IActionResult Login()
        {
            return View();
        }

        // POST Login
        [HttpPost]
        public IActionResult Login(User_Login u)
        {
            var user = _context.User_Logins
                .FirstOrDefault(x => x.Email.ToLower() == u.Email.ToLower() && x.Password == u.Password);

            if (user != null)
            {
                TempData["LoginMessage"] = "Login successful";
                return RedirectToAction("Dashboard", "Dash");
            }

            ViewBag.Msg = "Invalid Email or Password";
            return View();
        }
    }
}
