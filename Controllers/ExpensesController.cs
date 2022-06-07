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
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Expenses.Include(e => e.Organization).Include(e => e.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses
                .Include(e => e.Organization)
                .Include(e => e.Product)
                .FirstOrDefaultAsync(m => m.Expenses_Id == id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name");
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseVM expensesVM)
        {
            if (ModelState.IsValid)
            {
                Expenses expenses = new()
                {
                    Expenditure_Name = expensesVM.Expenditure_Name,
                    Total_Price = expensesVM.Total_Price,
                    Product_Id = expensesVM.Product_Id,
                    Org_Id = expensesVM.Org_Id,
                    Expenditure_Price = expensesVM.Expenditure_Price,
                    
                };
                _context.Add(expenses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            else
            {
                ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name");
                ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
                return View();
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", expensesVM.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", expensesVM.Product_Id);
            return View(expensesVM);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses.FindAsync(id);
            if (expenses == null)
            {
                return NotFound();
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", expenses.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", expenses.Product_Id);
            return View(expenses);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( ExpenseVM expenses)
        {
           
            if (ModelState.IsValid)
            {
                Expenses p = _context.Expenses.Find(expenses.Expenses_Id);
                if(p!=null)
                {
                    p.Expenditure_Name = expenses.Expenditure_Name;
                    p.Expenditure_Price = expenses.Expenditure_Price;
                    p.Total_Price = expenses.Total_Price;
                    p.Org_Id = expenses.Org_Id;
                    p.Product_Id = expenses.Product_Id;
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }
                
                 return RedirectToAction(nameof(Index));
            
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", expenses.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", expenses.Product_Id);
            return View(expenses);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses
                .Include(e => e.Organization)
                .Include(e => e.Product)
                .FirstOrDefaultAsync(m => m.Expenses_Id == id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Expenses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Expenses'  is null.");
            }
            var expenses = await _context.Expenses.FindAsync(id);
            if (expenses != null)
            {
                _context.Expenses.Remove(expenses);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensesExists(int id)
        {
          return (_context.Expenses?.Any(e => e.Expenses_Id == id)).GetValueOrDefault();
        }
    }
}
