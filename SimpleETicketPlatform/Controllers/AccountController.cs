using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Account;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(IAccountService accountService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.accountService = accountService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var account = await accountService.FindAccountByEmailAsync(model.Email);
            if (account != null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(account, model.Password);
                if (passwordCheck)
                {
                    var result = await signInManager.PasswordSignInAsync(account, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(PersonalAccount));
                    }
                }
            }
            TempData["Error"] = "Wrong credentials. Try again!";
            return View(model);
        }

        private object PersonalAccount()
        {
            throw new NotImplementedException();
        }
    }
}
