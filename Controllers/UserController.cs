namespace Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
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

        public IActionResult Edit(int userId)
        {
            var user = MainDbContext.Instance.Users.Where(i => i.Id == userId).SingleOrDefault();

            return this.View(user);
        }

        [HttpPost]
        public IActionResult Save()
        {
            return this.View("Edit");
        }
    }
}
