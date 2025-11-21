using Axioms_Satyendra_Singh.Data;
using Axioms_Satyendra_Singh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Axioms_Satyendra_Singh.Controllers
{
    public class DashController : Controller
    {
        private readonly AppDbContext _context;

        public DashController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard(string q = "")
        {
            var customersQuery = _context.Customer.AsQueryable();
            var employeesQuery = _context.Employee.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                customersQuery = customersQuery.Where(c => EF.Functions.Like(c.Name, $"%{q}%"));
                employeesQuery = employeesQuery.Where(e => EF.Functions.Like(e.Name, $"%{q}%"));
            }

            var vm = new DashboardViewModel
            {
                Report = new ReportViewModel
                {
                    Total_Customers = await _context.Customer.CountAsync(),
                    Total_Employees = await _context.Employee.CountAsync()
                },
                Customers = await customersQuery.OrderBy(c => c.Id).ToListAsync(),
                Employees = await employeesQuery.OrderBy(e => e.Id).ToListAsync(),
                SearchQuery = q ?? string.Empty
            };

            return View(vm);
        }
    }
}
