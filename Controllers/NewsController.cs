namespace Server.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Server.Models;

    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return this.View(new NewsCollection(MainDbContext.Instance.News));
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(News userModel)
        {
            return this.View();
        }

        public IActionResult Show(int @event)
        {
            return this.View(MainDbContext.Instance.News.Where(n => n.Id == @event).SingleOrDefault());
        }

        public IActionResult Edit(int @event)
        {
            return this.View(MainDbContext.Instance.News.Where(n => n.Id == @event).SingleOrDefault());
        }

        [HttpPost]
        public IActionResult Delete(int @event)
        {
            return this.View(MainDbContext.Instance.News.Where(n => n.Id == @event).SingleOrDefault());
        }

        [HttpPost]
        public IActionResult Save(Event model)
        {
            Console.WriteLine("Saving model!");

            return this.View("Index");
        }

        public IActionResult CreateDummyNews()
        {
            var news = MainDbContext.Instance.News;
            var rnd = new Random();
            var offset = DateTime.Now.Ticks;


            for (int i = 0; i < 5; i++)
            {
                news.Add(new News()
                {
                    Title = "News " + (i + offset).ToString(),
                    Content = "Dummy-Content...",
                    CreationTime = DateTime.Now.AddDays(rnd.Next(50)),
                });
            }

            MainDbContext.Instance.SaveChanges();

            return this.RedirectToAction("Index", new NewsCollection(MainDbContext.Instance.News));
        }
    }
}