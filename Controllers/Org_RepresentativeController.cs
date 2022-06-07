using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientManagementSys.Areas.Identity.Data;
using ClientManagementSys.Models;
using ClientManagementSys.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace ClientManagementSys.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Org_RepresentativeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Org_RepresentativeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Org_Representative
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Org_Representatives.Include(o => o.Organization);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Org_Representative/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Org_Representatives == null)
            {
                return NotFound();
            }

            var org_Representative = await _context.Org_Representatives
                .Include(o => o.Organization)
                .FirstOrDefaultAsync(m => m.Representative_Id == id);
            if (org_Representative == null)
            {
                return NotFound();
            }

            return View(org_Representative);
        }

        // GET: Org_Representative/Create
        public IActionResult Create()
        {
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name");
            return View();
        }

        // POST: Org_Representative/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Org_RepresentativeVM org_RepresentativeVM)
        {
            if (ModelState.IsValid)
            {
                Org_Representative org_Representative = new()
                {
                    Representative_Id = org_RepresentativeVM.Representative_Id,
                    Org_Id = org_RepresentativeVM.Org_Id,
                    Representative_FullName = org_RepresentativeVM.Representative_FullName,
                    Representative_Email = org_RepresentativeVM.Representative_Email,
                    ContactNo = org_RepresentativeVM.ContactNo,
                    Representative_Address = org_RepresentativeVM.Representative_Address,
                    Representative_Status = org_RepresentativeVM.Representative_Status
                };
                _context.Add(org_Representative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name");
                return View();
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", org_RepresentativeVM.Org_Id);
            return View(org_RepresentativeVM);
        }

        // GET: Org_Representative/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Org_Representatives == null)
            {
                return NotFound();
            }

            var org_Representative = await _context.Org_Representatives.FindAsync(id);
            if (org_Representative == null)
            {
                return NotFound();
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", org_Representative.Org_Id);
            return View(org_Representative);
        }

        // POST: Org_Representative/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Org_RepresentativeVM org_Representative)
        {
           

            if (ModelState.IsValid)
            {
                Org_Representative p =_context.Org_Representatives.Find(org_Representative.Representative_Id);
                if (p != null)
                {
                    p.Org_Id = org_Representative.Org_Id;
                    p.Representative_FullName = org_Representative.Representative_FullName;
                    p.Representative_Email = org_Representative.Representative_Email;
                    p.ContactNo = org_Representative.ContactNo;
                    p.Representative_Address = org_Representative.Representative_Address;
                    p.Representative_Status = org_Representative.Representative_Status;
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", org_Representative.Org_Id);
            return View(org_Representative);
        }

        // GET: Org_Representative/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Org_Representatives == null)
            {
                return NotFound();
            }

            var org_Representative = await _context.Org_Representatives
                .Include(o => o.Organization)
                .FirstOrDefaultAsync(m => m.Representative_Id == id);
            if (org_Representative == null)
            {
                return NotFound();
            }

            return View(org_Representative);
        }

        // POST: Org_Representative/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Org_Representatives == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Org_Representatives'  is null.");
            }
            var org_Representative = await _context.Org_Representatives.FindAsync(id);
            if (org_Representative != null)
            {
                _context.Org_Representatives.Remove(org_Representative);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Org_RepresentativeExists(int id)
        {
          return (_context.Org_Representatives?.Any(e => e.Representative_Id == id)).GetValueOrDefault();
        }
    }
}
