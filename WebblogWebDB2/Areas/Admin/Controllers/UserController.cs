using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebblogWebDB2.Models;
using WebblogWebDB2.ViewModelsVM;

namespace WebblogWebDB2.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }


        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            if (id == null) return NotFound();
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            var roles = _roleManager.Roles.Select(x => x.Name).ToList();

           

            UserRoleVM userRoleVM = new()
            {
                User = user,
                Roles = roles.Except(userRoles).ToList()
            };
            return View(userRoleVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string id, string role)
        {
            if (id == null) return NotFound();
            User user = (await _userManager.FindByIdAsync(id));
            if (user == null) return NotFound();

            var UserRole = await _userManager.AddToRoleAsync(user, role);

            if (!UserRole.Succeeded)
            {
                ModelState.AddModelError("error", "role!!");
            }
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Edit(string Userid)
        {
            if (Userid == null) return NotFound();
            User user = await _userManager.FindByIdAsync(Userid);
            if (user == null) return NotFound();
            return View(user);
        }


           
        public async Task<IActionResult> Delete(string Userid, string role)
        {
            if (Userid == null || role == null) return NotFound();
            User user = await _userManager.FindByIdAsync(Userid);
            if (user == null) return NotFound();

            IdentityResult result = await _userManager.RemoveFromRoleAsync(user, role);

            if (!result.Succeeded)
            {
                ViewBag.Errors = "Errors";
                return View();
            }
            return RedirectToAction("Index");

        }
    }
}
