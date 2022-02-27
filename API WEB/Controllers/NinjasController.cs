#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_WEB.DAO;
using API_WEB.Models;

namespace API_WEB.Controllers
{
    [Route("api/ninjas")]
    [ApiController]
    public class NinjasController : ControllerBase
    {
        private readonly NinjaContext _context;

        public NinjasController(NinjaContext context)
        {
            _context = context;
        }

        // GET: api/Ninjas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ninja>>> GetNinjas()
        {
            return await _context.Ninjas.ToListAsync();
        }

        // GET: api/Ninjas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ninja>> GetNinja(long id)
        {
            var ninja = await _context.Ninjas.FindAsync(id);

            if (ninja == null)
            {
                return NotFound();
            }

            return ninja;
        }

        // PUT: api/Ninjas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNinja(long id, Ninja ninja)
        {
            if (id != ninja.Id)
            {
                return BadRequest();
            }

            _context.Entry(ninja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NinjaExists(id))
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

        // POST: api/Ninjas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ninja>> PostNinja(Ninja ninja)
        {
            _context.Ninjas.Add(ninja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNinja", new { id = ninja.Id }, ninja);
        }

        // DELETE: api/Ninjas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNinja(long id)
        {
            var ninja = await _context.Ninjas.FindAsync(id);
            if (ninja == null)
            {
                return NotFound();
            }

            _context.Ninjas.Remove(ninja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NinjaExists(long id)
        {
            return _context.Ninjas.Any(e => e.Id == id);
        }
    }
}
