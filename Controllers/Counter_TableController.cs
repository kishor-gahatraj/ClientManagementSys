using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientManagementSys.Areas.Identity.Data;
using ClientManagementSys.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClientManagementSys.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Counter_TableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Counter_TableController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Counter_Table
        public async Task<IActionResult> Index()
        {
              return _context.Counter_Tables != null ? 
                          View(await _context.Counter_Tables.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Counter_Tables'  is null.");
        }

        // GET: Counter_Table/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Counter_Tables == null)
            {
                return NotFound();
            }

            var counter_Table = await _context.Counter_Tables
                .FirstOrDefaultAsync(m => m.Counter_Id == id);
            if (counter_Table == null)
            {
                return NotFound();
            }

            return View(counter_Table);
        }

        // GET: Counter_Table/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Counter_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Counter_Id,Total_Organization,Product_Quantity,Total_User")] Counter_Table counter_Table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(counter_Table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(counter_Table);
        }

        // GET: Counter_Table/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Counter_Tables == null)
            {
                return NotFound();
            }

            var counter_Table = await _context.Counter_Tables.FindAsync(id);
            if (counter_Table == null)
            {
                return NotFound();
            }
            return View(counter_Table);
        }

        // POST: Counter_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Counter_Id,Total_Organization,Product_Quantity,Total_User")] Counter_Table counter_Table)
        {
            if (id != counter_Table.Counter_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(counter_Table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Counter_TableExists(counter_Table.Counter_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(counter_Table);
        }

        // GET: Counter_Table/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Counter_Tables == null)
            {
                return NotFound();
            }

            var counter_Table = await _context.Counter_Tables
                .FirstOrDefaultAsync(m => m.Counter_Id == id);
            if (counter_Table == null)
            {
                return NotFound();
            }

            return View(counter_Table);
        }

        // POST: Counter_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Counter_Tables == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Counter_Tables'  is null.");
            }
            var counter_Table = await _context.Counter_Tables.FindAsync(id);
            if (counter_Table != null)
            {
                _context.Counter_Tables.Remove(counter_Table);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Counter_TableExists(int id)
        {
          return (_context.Counter_Tables?.Any(e => e.Counter_Id == id)).GetValueOrDefault();
        }
    }
}
