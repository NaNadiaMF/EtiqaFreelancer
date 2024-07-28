using EtiqaWebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace EtiqaWebApp1.ViewComponent
{
    public class FreelancerViewComponent
    {
        private readonly FreelancerDbContext _context;

        public FreelancerViewComponent(FreelancerDbContext context)
        {
            _context = context;
        }

        /*public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.MstUser.ToListAsync);
        }*/
    }
}
