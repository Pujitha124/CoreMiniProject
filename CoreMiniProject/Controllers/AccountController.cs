using CoreMiniProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreMiniProject.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> obj1, SignInManager<IdentityUser> obj2)
        {
            this.userManager = obj1;
            this.signInManager = obj2;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                //IdentityUser represents a new user with a given set of attributes
                IdentityUser identityUser = new IdentityUser
                {
                    UserName = userModel.Name,
                    Email = userModel.Email,
                    PhoneNumber = userModel.Mobile
                };
                //Creates a new user and returns a result which tells about success or failure
                var result = await userManager.CreateAsync(identityUser, userModel.Password);
                if (result.Succeeded)
                {
                    //Performing a Sign-In into the appliction
                    await signInManager.SignInAsync(identityUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var Error in result.Errors)
                    {
                        //Displaying error details to the user
                        ModelState.AddModelError("", Error.Description);
                    }
                }
            }
            return View(userModel);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    loginModel.Name,
                    loginModel.Password,
                    loginModel.RememberMe,
                    false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(loginModel.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }

            // ✔️ Now handles both ModelState false and failed login
            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


    }
}
