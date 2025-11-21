using Microsoft.AspNetCore.Mvc;
using Axioms_Satyendra_Singh.Data;
using System.Threading.Tasks;

namespace Axioms_Satyendra_Singh.Controllers
{
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: /Setting/Settings
        public IActionResult Settings()
        {
            ViewBag.EmployeeCount = _context.Employee?.Count() ?? 0;
            ViewBag.CustomerCount = _context.Customer?.Count() ?? 0;
            return View();
        }

        // POST: /Setting/ClearEmployees
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearEmployees()
        {
            if (_context.Employee != null)
            {
                _context.Employee.RemoveRange(_context.Employee);
                await _context.SaveChangesAsync();
                TempData["SettingsMessage"] = "All employee records have been cleared.";
            }
            return RedirectToAction("Settings");
        }

        // POST: /Setting/ClearCustomers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearCustomers()
        {
            if (_context.Customer != null)
            {
                _context.Customer.RemoveRange(_context.Customer);
                await _context.SaveChangesAsync();
                TempData["SettingsMessage"] = "All customer records have been cleared.";
            }
            return RedirectToAction("Settings");
        }
    }
}
