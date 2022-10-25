using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EfPowerToolsUni.Data;
using EfPowerToolsUni.Models;

namespace EfPowerToolsUni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewgradesController : ControllerBase
    {
        private readonly universityContext _context;

        public ViewgradesController(universityContext context)
        {
            _context = context;
        }

        // GET: api/Viewgrades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viewgrade>>> GetViewgrades()
        {
            return await _context.Viewgrades.ToListAsync();
        }

        // GET: api/Viewgrades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viewgrade>> GetViewgrade(int id)
        {
            var viewgrade = await _context.Viewgrades.FindAsync(id);

            if (viewgrade == null)
            {
                return NotFound();
            }

            return viewgrade;
        }

        // PUT: api/Viewgrades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViewgrade(int id, Viewgrade viewgrade)
        {
            if (id != viewgrade.Idgrade)
            {
                return BadRequest();
            }

            _context.Entry(viewgrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewgradeExists(id))
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

        // POST: api/Viewgrades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Viewgrade>> PostViewgrade(Viewgrade viewgrade)
        {
            _context.Viewgrades.Add(viewgrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViewgrade", new { id = viewgrade.Idgrade }, viewgrade);
        }

        // DELETE: api/Viewgrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViewgrade(int id)
        {
            var viewgrade = await _context.Viewgrades.FindAsync(id);
            if (viewgrade == null)
            {
                return NotFound();
            }

            _context.Viewgrades.Remove(viewgrade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViewgradeExists(int id)
        {
            return _context.Viewgrades.Any(e => e.Idgrade == id);
        }
    }
}
