namespace Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Server.Models;

    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Models.User userModel)
        {
            return View();
        }
    }
}
