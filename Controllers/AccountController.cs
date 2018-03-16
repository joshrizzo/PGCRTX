using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using PGCRTX.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetXPlat.Models;
using Omu.ValueInjecter;

namespace PGCRTX.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> log;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AccountController> log)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.log = log;
            roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }

        [HttpGet]
        public virtual ActionResult Register(string returnUrl = null)
        {
            var model = new RegisterViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            var user = new ApplicationUser();
            user.InjectFrom(model);
            user.UserName = user.Email;

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(model);
            }

            addPermissions(user);

            await signInManager.SignInAsync(user, isPersistent: false);
            log.LogInformation(3, "User Registered");
            return Redirect(returnUrl ?? "/");
        }

        private async void addPermissions(ApplicationUser user)
        {
            if (!await userManager.IsInRoleAsync(user, Roles.Admin))
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }
    }
}