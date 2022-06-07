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
    public class Progress_ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Progress_ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Progress_Report
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Progress_Reports.Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Progress_Report/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Progress_Reports == null)
            {
                return NotFound();
            }

            var progress_Report = await _context.Progress_Reports
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Report_Id == id);
            if (progress_Report == null)
            {
                return NotFound();
            }

            return View(progress_Report);
        }

        // GET: Progress_Report/Create
        public IActionResult Create()
        {
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            return View();
        }

        // POST: Progress_Report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Progress_ReportVM progress_ReportVM)
        {
            if (ModelState.IsValid)
            {
                Progress_Report progress_Report = new()
                {
                    Product_Id = progress_ReportVM.Product_Id,
                    Report_Id = progress_ReportVM.Report_Id,
                    Completion_Date = progress_ReportVM.Completion_Date,
                    LastUpdated_Date = progress_ReportVM.LastUpdated_Date,
                    Supervisor = progress_ReportVM.Supervisor,
                    Current_Milestone = progress_ReportVM.Current_Milestone,
                    Total_Milestone = progress_ReportVM.Total_Milestone,
                };
                _context.Add(progress_Report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", progress_ReportVM.Product_Id);
            return View(progress_ReportVM);
        }

        // GET: Progress_Report/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Progress_Reports == null)
            {
                return NotFound();
            }

            var progress_Report = await _context.Progress_Reports.FindAsync(id);
            if (progress_Report == null)
            {
                return NotFound();
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", progress_Report.Product_Id);
            return View(progress_Report);
        }

        // POST: Progress_Report/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Progress_ReportVM progress_Report)
        {
           

            if (ModelState.IsValid)
            {
                Progress_Report p = _context.Progress_Reports.Find(progress_Report.Report_Id);
                if (p != null)
                {
                    p.Product_Id = progress_Report.Product_Id;
                    p.Completion_Date = progress_Report.Completion_Date;
                    p.LastUpdated_Date = progress_Report.LastUpdated_Date;
                    p.Supervisor = progress_Report.Supervisor;
                    p.Current_Milestone = progress_Report.Current_Milestone;
                    p.Total_Milestone = progress_Report.Total_Milestone;
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
               
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", progress_Report.Product_Id);
            return View(progress_Report);
        }

        // GET: Progress_Report/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Progress_Reports == null)
            {
                return NotFound();
            }

            var progress_Report = await _context.Progress_Reports
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Report_Id == id);
            if (progress_Report == null)
            {
                return NotFound();
            }

            return View(progress_Report);
        }

        // POST: Progress_Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Progress_Reports == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Progress_Reports'  is null.");
            }
            var progress_Report = await _context.Progress_Reports.FindAsync(id);
            if (progress_Report != null)
            {
                _context.Progress_Reports.Remove(progress_Report);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Progress_ReportExists(int id)
        {
          return (_context.Progress_Reports?.Any(e => e.Report_Id == id)).GetValueOrDefault();
        }
    }
}
