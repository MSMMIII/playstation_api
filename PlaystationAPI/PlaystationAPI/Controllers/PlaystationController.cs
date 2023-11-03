using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaystationAPI.Data;
using PlaystationAPI.Models;

namespace PlaystationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaystationController : ControllerBase
    {
        private readonly PlaystationContext _context;

        public PlaystationController(PlaystationContext context)
        {
            _context = context;
        }

        // GET: api/Playstation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playstation>>> GetPlaystations()
        {
          if (_context.Playstations == null)
          {
              return NotFound();
          }
            return await _context.Playstations.ToListAsync();
        }

        // GET: api/Playstation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playstation>> GetPlaystation(int id)
        {
          if (_context.Playstations == null)
          {
              return NotFound();
          }
            var playstation = await _context.Playstations.FindAsync(id);

            if (playstation == null)
            {
                return NotFound();
            }

            return playstation;
        }

        // PUT: api/Playstation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaystation(int id, Playstation playstation)
        {
            if (id != playstation.Id)
            {
                return BadRequest();
            }

            _context.Entry(playstation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaystationExists(id))
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

        // POST: api/Playstation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playstation>> PostPlaystation(Playstation playstation)
        {
          if (_context.Playstations == null)
          {
              return Problem("Entity set 'PlaystationContext.Playstations'  is null.");
          }
            _context.Playstations.Add(playstation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaystation", new { id = playstation.Id }, playstation);
        }

        // DELETE: api/Playstation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaystation(int id)
        {
            if (_context.Playstations == null)
            {
                return NotFound();
            }
            var playstation = await _context.Playstations.FindAsync(id);
            if (playstation == null)
            {
                return NotFound();
            }

            _context.Playstations.Remove(playstation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaystationExists(int id)
        {
            return (_context.Playstations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
