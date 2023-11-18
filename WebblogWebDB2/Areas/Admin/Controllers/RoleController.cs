using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebblogWebDB2.Areas.Admin.Controllers
{
        [Area(nameof(Admin))]
    //[Authorize (Roles = "Admin, Admin Editor")]
       public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole ıdentityRole)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
 
            var checkrole = await _roleManager.FindByNameAsync(ıdentityRole.Name);

            if (checkrole != null)
            {
                ViewBag.Error = "Error";
                return View();
            }

            await _roleManager.CreateAsync(ıdentityRole);
            return RedirectToAction("Index");
        }  

    }
}
