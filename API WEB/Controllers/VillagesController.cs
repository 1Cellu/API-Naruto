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
    public class VillagesController : ControllerBase
    {
        private readonly NinjaContext _context;

        public VillagesController(NinjaContext context)
        {
            _context = context;
        }

        // GET: api/Villages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Village>>> GetVillage()
        {
            return await _context.Village.ToListAsync();
        }

        // GET: api/Villages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Village>> GetVillage(long id)
        {
            var village = await _context.Village.FindAsync(id);

            if (village == null)
            {
                return NotFound();
            }

            return village;
        }

        // PUT: api/Villages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVillage(long id, Village village)
        {
            if (id != village.Id)
            {
                return BadRequest();
            }

            _context.Entry(village).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VillageExists(id))
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

        // POST: api/Villages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Village>> PostVillage(Village village)
        {
            _context.Village.Add(village);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVillage", new { id = village.Id }, village);
        }

        // DELETE: api/Villages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVillage(long id)
        {
            var village = await _context.Village.FindAsync(id);
            if (village == null)
            {
                return NotFound();
            }

            _context.Village.Remove(village);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VillageExists(long id)
        {
            return _context.Village.Any(e => e.Id == id);
        }
    }
}
