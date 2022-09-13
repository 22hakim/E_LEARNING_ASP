using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Learning_API.Data;
using E_Learning_API.Models;

namespace E_Learning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignementController : ControllerBase
    {
        private readonly ElearningDataContext _context;

        public AssignementController(ElearningDataContext context)
        {
            _context = context;
        }

        // GET: api/Assignement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignement>>> GetAssignements()
        {
          if (_context.Assignements == null)
          {
              return NotFound();
          }
            return await _context.Assignements.ToListAsync();
        }

        // GET: api/Assignement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignement>> GetAssignement(int id)
        {
          if (_context.Assignements == null)
          {
              return NotFound();
          }
            var assignement = await _context.Assignements.FindAsync(id);

            if (assignement == null)
            {
                return NotFound();
            }

            return assignement;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignement(int id, Assignement assignement)
        {
            if (id != assignement.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignementExists(id))
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

        // POST: api/Assignement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assignement>> PostAssignement(Assignement assignement)
        {
          if (_context.Assignements == null)
          {
              return Problem("Entity set 'ElearningDataContext.Assignements'  is null.");
          }
            _context.Assignements.Add(assignement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignement", new { id = assignement.Id }, assignement);
        }

        // DELETE: api/Assignement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignement(int id)
        {
            if (_context.Assignements == null)
            {
                return NotFound();
            }
            var assignement = await _context.Assignements.FindAsync(id);
            if (assignement == null)
            {
                return NotFound();
            }

            _context.Assignements.Remove(assignement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignementExists(int id)
        {
            return (_context.Assignements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
