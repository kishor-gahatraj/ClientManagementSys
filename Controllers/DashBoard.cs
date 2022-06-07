using ClientManagementSys.Areas.Identity.Data;
using ClientManagementSys.Models;
using ClientManagementSys.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementSys.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashBoardController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()

        {
             var counter = _context.Counter_Tables.FirstOrDefault();


            return View(counter);
        }
        

        
        //    return _context.Products != null ?
        //                PartialView(await _context.Products.ToListAsync()) :
        //                Problem("Entity set 'ApplicationDbContext.Products'  is null.");
        //}






    }

}

