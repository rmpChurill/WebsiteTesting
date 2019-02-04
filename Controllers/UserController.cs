namespace Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Server.Models;

    public class UserController : Controller
    {
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

        public IActionResult Edit()
        {
            return this.View();
        }
    }
}
