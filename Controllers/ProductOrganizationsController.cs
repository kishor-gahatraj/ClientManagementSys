﻿using System;
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
    public class ProductOrganizationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductOrganizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductOrganizations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductOrganizations.Include(p => p.Organization).Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductOrganizations/Details/5
        public async Task<IActionResult> Details(int? Product_Id , int? Org_Id)
        {
            if (Product_Id == null || Org_Id==null || _context.ProductOrganizations == null)
            {
                return NotFound();
            }

            var productOrganization = await _context.ProductOrganizations
                .Include(p => p.Organization)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Product_Id == Product_Id && m.Org_Id==Org_Id );
            if (productOrganization == null)
            {
                return NotFound();
            }

            return View(productOrganization);
        }

        // GET: ProductOrganizations/Create
        public IActionResult Create()
        {
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name");
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            return View();
        }

        // POST: ProductOrganizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductOrganizationVM productOrganizationVM)
        {
            if (ModelState.IsValid)
            {
                ProductOrganization productOrganization = new()
                {
                    Product_Id = productOrganizationVM.Product_Id,
                    Org_Id = productOrganizationVM.Org_Id
                    
                };
                _context.Add(productOrganization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", productOrganizationVM.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", productOrganizationVM.Product_Id);
            return View(productOrganizationVM);
        }

        // GET: ProductOrganizations/Edit/5
        public async Task<IActionResult> Edit(ProductOrganization productOrganization)
        {
            var ProductOrganization = await _context.ProductOrganizations.FindAsync(productOrganization.Product_Id, productOrganization.Org_Id);
            //if (product == null || organization == null)
            //{
            //    return NotFound();
            //}

            //var productOrganizationVM = await _context.ProductOrganizations.FindAsync(product.Product_Id, organization.Org_Id);
            //if (productOrganizationVM == null)
            //{
            //    return NotFound();
            //}
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", productOrganization.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", productOrganization.Product_Id);
            return View(productOrganization);
        }
        //{
        //    if (id == null || _context.ProductOrganizations == null)
        //    {
        //        return NotFound();
        //    }

        //    var productOrganization = await _context.ProductOrganizations.FindAsync(id);
        //    if (productOrganization == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Id", productOrganization.Org_Id);
        //    ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Id", productOrganization.Product_Id);
        //    return View(productOrganization);
        //}

        // POST: ProductOrganizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductOrganizationVM productOrganization)
        {
          

            if (ModelState.IsValid)
            {
                var p = await _context.ProductOrganizations.FindAsync(productOrganization.Product_Id, productOrganization.Org_Id);
                if (p != null)
                {
                    p.Product_Id = productOrganization.Product_Id;
                    p.Org_Id = productOrganization.Org_Id;
                    _context.Update(p);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Org_Id"] = new SelectList(_context.Organizations, "Org_Id", "Org_Name", productOrganization.Org_Id);
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", productOrganization.Product_Id);
            return View(productOrganization);
        }

        // GET: ProductOrganizations/Delete/5
        public async Task<IActionResult> Delete(int Product_Id, int Org_Id)
        {
            if (Product_Id== null ||Org_Id ==null || _context.ProductOrganizations == null)
            {
                return NotFound();
            }
            
            var productOrganization = await _context.ProductOrganizations
                .Include(p => p.Organization)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Product_Id == Product_Id && m.Org_Id == Org_Id);
            if (productOrganization == null)
            {
                return NotFound();
            }

            return View(productOrganization);
        }

        // POST: ProductOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Product_Id ,int Org_Id)
        {
            if (_context.ProductOrganizations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductOrganizations'  is null.");
            }
            var productOrganization = await _context.ProductOrganizations.FindAsync(Product_Id, Org_Id);
            if (productOrganization != null)
            {
                _context.ProductOrganizations.Remove(productOrganization);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public async Task<IActionResult> AddProduct(int Org_Id)
        //{
        //    ViewBag.Org_Id = Org_Id;
        //    var role = await _context.Organizations.FindAsync(Org_Id);
        //    if (role == null)
        //    {
        //        ViewBag.ErrorMessage = $"Role with Id = {Org_Id} cannot be found";
        //        return View("NotFound");
        //    }
        //    var model = new List<ProductViewModel>();
        //    foreach (var user in await _context.Products.ToListAsync())
        //    {
        //        var ProductViewModel = new ProductViewModel
        //        {
        //            Product_Id = user.Product_Id,
        //            Product_Name = user.Product_Name
        //        };
        //        if (await _context.ProductOrganizations.AnyAsync(r => r.Product_Id == user.Product_Id && r.Org_Id == Org_Id))
        //        {
        //            ProductViewModel.IsSelected = true;
        //        }
        //        else
        //        {
        //            ProductViewModel.IsSelected = false;
        //        }
               
        //        model.Add(ProductViewModel);
        //    }
        //    return View(model);
        //}


        
        
        private bool ProductOrganizationExists(int id)
        {
          return (_context.ProductOrganizations?.Any(e => e.Product_Id == id)).GetValueOrDefault();
        }
    }
}
