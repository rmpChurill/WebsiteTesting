namespace Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Server.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult CreateAccount()
        {
            return this.View();
        }

        public IActionResult Edit(string userId)
        {
            var user = MainDbContext.Instance.Users.Where(i => i.Id == userId).SingleOrDefault();

            return this.View(user);
        }

        [HttpPost]
        public IActionResult Save(User model)
        {
            return this.View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var returnUrl = string.IsNullOrEmpty(model.ReturnUrl) ? Url.Action("Index", "Home") : model.ReturnUrl;
            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (this.ModelState.IsValid && result.Succeeded)
            {
                return this.RedirectPermanent(returnUrl);
            }

            return this.View();
        }

        public IActionResult Login(string returnUrl = null)
        {
            return this.View(new LoginModel() { ReturnUrl = returnUrl });
        }

        public async Task<IActionResult> Logout(string returnUrl)
        {
            await this.signInManager.SignOutAsync();

            if (string.IsNullOrEmpty(returnUrl))
            {
                return this.View();
            }

            return this.RedirectPermanent(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var returnUrl = string.IsNullOrEmpty(model.ReturnUrl) ? Url.Action("Index", "Home") : model.ReturnUrl;

            if (this.ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await this.userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    // var callbackUrl = Url.Page(
                    //     "/Account/ConfirmEmail",
                    //     pageHandler: null,
                    //     values: new { userId = user.Id, code = code },
                    //     protocol: Request.Scheme);

                    // await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    
                    return this.LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.View();
        }

        public IActionResult Register(string returnUrl = null)
        {
            return this.View(new RegisterModel() { ReturnUrl = returnUrl });
        }
    }
}
