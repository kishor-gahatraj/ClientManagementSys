using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientManagementSys.Areas.Identity.Data;
using ClientManagementSys.Models;

namespace ClientManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AMCs1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AMCs1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AMCs1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AMC>>> GetAMCs()
        {
          if (_context.AMCs == null)
          {
              return NotFound();
          }
            return await _context.AMCs.ToListAsync();
        }

        // GET: api/AMCs1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AMC>> GetAMC(int id)
        {
          if (_context.AMCs == null)
          {
              return NotFound();
          }
            var aMC = await _context.AMCs.FindAsync(id);

            if (aMC == null)
            {
                return NotFound();
            }

            return aMC;
        }

        // PUT: api/AMCs1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAMC(int id, AMC aMC)
        {
            if (id != aMC.AMC_Id)
            {
                return BadRequest();
            }

            _context.Entry(aMC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AMCExists(id))
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

        // POST: api/AMCs1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AMC>> PostAMC(AMC aMC)
        {
          if (_context.AMCs == null)
          {
              return Problem("Entity set 'ApplicationDbContext.AMCs'  is null.");
          }
            _context.AMCs.Add(aMC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAMC", new { id = aMC.AMC_Id }, aMC);
        }

        // DELETE: api/AMCs1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAMC(int id)
        {
            if (_context.AMCs == null)
            {
                return NotFound();
            }
            var aMC = await _context.AMCs.FindAsync(id);
            if (aMC == null)
            {
                return NotFound();
            }

            _context.AMCs.Remove(aMC);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AMCExists(int id)
        {
            return (_context.AMCs?.Any(e => e.AMC_Id == id)).GetValueOrDefault();
        }
    }
}
