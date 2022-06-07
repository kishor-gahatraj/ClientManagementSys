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

namespace ClientManagementSys.Controllers
{
    public class Product_VersionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Product_VersionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Product_Version
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product_Versions.Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Product_Version/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product_Versions == null)
            {
                return NotFound();
            }

            var product_Version = await _context.Product_Versions
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Product_VersionId == id);
            if (product_Version == null)
            {
                return NotFound();
            }

            return View(product_Version);
        }

        // GET: Product_Version/Create
        public IActionResult Create()
        {
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            return View();
        }

        // POST: Product_Version/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product_VersionVM product_VersionVM)
        {
            if (ModelState.IsValid)
            {
                Product_Version product_Version = new()
                {
                   
                    Created_Date = product_VersionVM.Created_Date,
                    Modified_Date = product_VersionVM.Modified_Date,
                    Product_Id = product_VersionVM.Product_Id,
                    Version = product_VersionVM.Version,
                    
                };
                _context.Add(product_Version);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", product_VersionVM.Product_Id);
            return View(product_VersionVM);
        }

        // GET: Product_Version/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product_Versions == null)
            {
                return NotFound();
            }

            var product_Version = await _context.Product_Versions.FindAsync(id);
            if (product_Version == null)
            {
                return NotFound();
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", product_Version.Product_Id);
            return View(product_Version);
        }

        // POST: Product_Version/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product_VersionVM product_Version)
        {
           

            if (ModelState.IsValid)
            {
                Product_Version p = _context.Product_Versions.Find(product_Version.Product_VersionId);
                if (p != null)
                {
                    
                    p.Created_Date = product_Version.Created_Date;
                    p.Modified_Date = product_Version.Modified_Date;
                    p.Product_Id = product_Version.Product_Id;
                    p.Version = product_Version.Version;
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }


                return RedirectToAction(nameof(Index));
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", product_Version.Product_Id);
            return View(product_Version);
        }

        // GET: Product_Version/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product_Versions == null)
            {
                return NotFound();
            }

            var product_Version = await _context.Product_Versions
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Product_VersionId == id);
            if (product_Version == null)
            {
                return NotFound();
            }

            return View(product_Version);
        }

        // POST: Product_Version/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product_Versions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product_Versions'  is null.");
            }
            var product_Version = await _context.Product_Versions.FindAsync(id);
            if (product_Version != null)
            {
                _context.Product_Versions.Remove(product_Version);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_VersionExists(int id)
        {
          return (_context.Product_Versions?.Any(e => e.Product_VersionId == id)).GetValueOrDefault();
        }
    }
}
