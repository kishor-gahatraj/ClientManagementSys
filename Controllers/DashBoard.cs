using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagementSys.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashBoard : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
