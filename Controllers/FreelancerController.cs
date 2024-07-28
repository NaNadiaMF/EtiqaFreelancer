using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EtiqaWebApp1.Models;
using EtiqaWebApp1.ViewComponent;

namespace EtiqaWebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly FreelancerDbContext _context;

        public FreelancerController(FreelancerDbContext context)
        {
            _context = context;
        }

        // GET: api/Freelancer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MstUser>>> GetMstUsers()
        {
            return await _context.MstUsers.ToListAsync();
        }

        // GET: api/Freelancer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MstUser>> GetMstUser(int id)
        {
            var mstUser = await _context.MstUsers.FindAsync(id);

            if (mstUser == null)
            {
                return NotFound();
            }

            return mstUser;
        }

        // PUT: api/Freelancer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMstUser(int id, MstUser mstUser)
        {
            if (id != mstUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(mstUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MstUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Freelancer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MstUser>> PostMstUser(MstUser mstUser)
        {
            _context.MstUsers.Add(mstUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MstUserExists(mstUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMstUser", new { id = mstUser.Id }, mstUser);
        }

        // DELETE: api/Freelancer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMstUser(int id)
        {
            var mstUser = await _context.MstUsers.FindAsync(id);
            if (mstUser == null)
            {
                return NotFound();
            }

            _context.MstUsers.Remove(mstUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MstUserExists(int id)
        {
            return _context.MstUsers.Any(e => e.Id == id);
        }

    }
}
