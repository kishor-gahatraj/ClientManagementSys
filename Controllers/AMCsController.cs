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
    public class AMCsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AMCsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AMCs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AMCs.Include(a => a.Organization).Include(a => a.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AMCs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AMCs == null)
            {
                return NotFound();
            }

            var aMC = await _context.AMCs
                .Include(a => a.Organization)
                .Include(a => a.Product)
                .FirstOrDefaultAsync(m => m.AMC_Id == id);
            if (aMC == null)
            {
                return NotFound();
            }

            return View(aMC);
        }

        // GET: AMCs/Create
       
        public IActionResult Create()
        {
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name");
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            return View();
        }

        // POST: AMCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AMCVM aMCVM)
        {
            if (ModelState.IsValid)
            {
                AMC aMC = new()
                {
                    AMC_Id = aMCVM.AMC_Id,
                   // AMC_Name = aMCVM.AMC_Name,
                    Maintenance_Charge = aMCVM.Maintenance_Charge,
                    Maintenance_Date = aMCVM.Maintenance_Date,
                    Org_Id = aMCVM.Org_Id,
                    Product_Id = aMCVM.Product_Id,

                };
                _context.Add(aMC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", aMCVM.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", aMCVM.Product_Id);
            return View(aMCVM);
        }

        // GET: AMCs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AMCs == null)
            {
                return NotFound();
            }

            var aMC = await _context.AMCs.FindAsync(id);
            if (aMC == null)
            {
                return NotFound();
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", aMC.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", aMC.Product_Id);
            return View(aMC);
        }

        // POST: AMCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AMCVM aMC)
        {
            

            if (ModelState.IsValid)
            {
                AMC p = _context.AMCs.Find(aMC.AMC_Id);
                if(p!=null)
                {
                   // p.AMC_Name = aMC.AMC_Name;
                    p.Maintenance_Charge = aMC.Maintenance_Charge;
                    p.Maintenance_Date = aMC.Maintenance_Date;
                    p.Org_Id = aMC.Org_Id;
                    p.Product_Id = aMC.Product_Id;
                    _context.Update(p);
                    await _context.SaveChangesAsync();

                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", aMC.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", aMC.Product_Id);
            return View(aMC);
        }

        // GET: AMCs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AMCs == null)
            {
                return NotFound();
            }

            var aMC = await _context.AMCs
                .Include(a => a.Organization)
                .Include(a => a.Product)
                .FirstOrDefaultAsync(m => m.AMC_Id == id);
            if (aMC == null)
            {
                return NotFound();
            }

            return View(aMC);
        }

        // POST: AMCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AMCs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AMCs'  is null.");
            }
            var aMC = await _context.AMCs.FindAsync(id);
            if (aMC != null)
            {
                _context.AMCs.Remove(aMC);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AMCExists(int id)
        {
          return (_context.AMCs?.Any(e => e.AMC_Id == id)).GetValueOrDefault();
        }
    }
}
