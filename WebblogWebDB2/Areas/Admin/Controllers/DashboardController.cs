using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebblogWebDB2.Areas.Admin.Controllers
{

    [Area(nameof(Admin))]
    [Authorize (Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
