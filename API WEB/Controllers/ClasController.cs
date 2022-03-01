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
    public class ClasController : ControllerBase
    {
        private readonly NinjaContext _context;

        public ClasController(NinjaContext context)
        {
            _context = context;
        }

        // GET: api/Clas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cla>>> GetCla()
        {
            return await _context.Cla.ToListAsync();
        }

        // GET: api/Clas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cla>> GetCla(long id)
        {
            var cla = await _context.Cla.FindAsync(id);

            if (cla == null)
            {
                return NotFound();
            }

            return cla;
        }

        // PUT: api/Clas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCla(long id, Cla cla)
        {
            if (id != cla.Id)
            {
                return BadRequest();
            }

            _context.Entry(cla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaExists(id))
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

        // POST: api/Clas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cla>> PostCla(Cla cla)
        {
            _context.Cla.Add(cla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCla", new { id = cla.Id }, cla);
        }

        // DELETE: api/Clas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCla(long id)
        {
            var cla = await _context.Cla.FindAsync(id);
            if (cla == null)
            {
                return NotFound();
            }

            _context.Cla.Remove(cla);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClaExists(long id)
        {
            return _context.Cla.Any(e => e.Id == id);
        }
    }
}
