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
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Invoices.Include(i => i.Organization).Include(i => i.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Invoices == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Organization)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Invoice_Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name");
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceVM invoiceVM)
        {
            if (ModelState.IsValid)
            {
                Invoice invoice = new() 
                {
                    Invoice_Id = invoiceVM.Invoice_Id,
                    Credit = invoiceVM.Credit,
                    Amount = invoiceVM.Amount,
                    Date = invoiceVM.Date,
                    Debit = invoiceVM.Debit,
                    Invoice_No = invoiceVM.Invoice_No,
                    Org_Id = invoiceVM.Org_Id,
                    Product_Id = invoiceVM.Product_Id
                };
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", invoiceVM.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", invoiceVM.Product_Id);
            return View(invoiceVM);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Invoices == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", invoice.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", invoice.Product_Id);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( InvoiceVM invoice)
        {
            

            if (ModelState.IsValid)
            {
                Invoice p = _context.Invoices.Find(invoice.Invoice_Id);
                if (p != null)
                {
                    p.Invoice_Id = invoice.Invoice_Id;
                    p.Credit = invoice.Credit;
                    p.Amount = invoice.Amount;
                    p.Date = invoice.Date;
                    p.Debit = invoice.Debit;
                    p.Invoice_No = invoice.Invoice_No;
                    p.Org_Id = invoice.Org_Id;
                    p.Product_Id = invoice.Product_Id;
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", invoice.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", invoice.Product_Id);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Invoices == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Organization)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Invoice_Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Invoices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Invoices'  is null.");
            }
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
          return (_context.Invoices?.Any(e => e.Invoice_Id == id)).GetValueOrDefault();
        }
    }
}
