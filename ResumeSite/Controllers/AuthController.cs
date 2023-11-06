using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResumeSite.Enums;
using ResumeSite.Models.IdentityEntities;
using ResumeSite.Models.ViewModels;

namespace ResumeSite.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        //[Authorize(Policy = "NotAuthorized")]
        [Authorize(Policy = "BlockAll")]
        [Route("register")]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "NotAuthorized")]
        [Authorize(Policy = "BlockAll")]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterObject registerObject)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = registerObject.Username,
                    Email = registerObject.Email,
                    PhoneNumber = registerObject.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, registerObject.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    if (await _roleManager.FindByNameAsync(UserRoles.Author.ToString()) is null)
                    {
                        await _roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.Author.ToString() });
                    }

                    await _userManager.AddToRoleAsync(user, UserRoles.Author.ToString());

                    return RedirectToAction("Index", "Publications");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("RegisterError", error.Description);
                }
            }

            return View(registerObject);
        }

        [HttpGet]
        [Authorize(Policy = "NotAuthorized")]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "NotAuthorized")]
        [Route("login")]
        public async Task<IActionResult> Login(LoginObject loginObject)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginObject.Username, loginObject.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Publications");
                }

                ModelState.AddModelError("LoginError", "Invalid login attempt");
            }

            return View(loginObject);
        }

        [HttpGet]
        [Authorize]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Publications");
        }
    }
}
