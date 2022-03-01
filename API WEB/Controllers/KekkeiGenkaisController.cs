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
    [Route("api/[controller]")]
    [ApiController]
    public class KekkeiGenkaisController : ControllerBase
    {
        private readonly NinjaContext _context;

        public KekkeiGenkaisController(NinjaContext context)
        {
            _context = context;
        }

        // GET: api/KekkeiGenkais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KekkeiGenkai>>> GetKekkeiGenkai()
        {
            return await _context.KekkeiGenkai.ToListAsync();
        }

        // GET: api/KekkeiGenkais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KekkeiGenkai>> GetKekkeiGenkai(long id)
        {
            var kekkeiGenkai = await _context.KekkeiGenkai.FindAsync(id);

            if (kekkeiGenkai == null)
            {
                return NotFound();
            }

            return kekkeiGenkai;
        }

        // PUT: api/KekkeiGenkais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKekkeiGenkai(long id, KekkeiGenkai kekkeiGenkai)
        {
            if (id != kekkeiGenkai.Id)
            {
                return BadRequest();
            }

            _context.Entry(kekkeiGenkai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KekkeiGenkaiExists(id))
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

        // POST: api/KekkeiGenkais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KekkeiGenkai>> PostKekkeiGenkai(KekkeiGenkai kekkeiGenkai)
        {
            _context.KekkeiGenkai.Add(kekkeiGenkai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKekkeiGenkai", new { id = kekkeiGenkai.Id }, kekkeiGenkai);
        }

        // DELETE: api/KekkeiGenkais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKekkeiGenkai(long id)
        {
            var kekkeiGenkai = await _context.KekkeiGenkai.FindAsync(id);
            if (kekkeiGenkai == null)
            {
                return NotFound();
            }

            _context.KekkeiGenkai.Remove(kekkeiGenkai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KekkeiGenkaiExists(long id)
        {
            return _context.KekkeiGenkai.Any(e => e.Id == id);
        }
    }
}
