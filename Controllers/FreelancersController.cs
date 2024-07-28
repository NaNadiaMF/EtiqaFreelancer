using EtiqaWebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EtiqaWebApp1.Controllers
{
    public class FreelancersController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        private readonly FreelancerDbContext _context;

        public FreelancersController(FreelancerDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MstUser mstUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mstUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
