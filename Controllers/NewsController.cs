namespace Server.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Server.Models;
    using Server.Utils;

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
        public IActionResult Save(News model)
        {
            model.LastEditedTime = DateTime.Now;

            var dbItem = MainDbContext.Instance.News.Where(n => n.Id == model.Id).SingleOrDefault();

            if (dbItem != null)
            {
                Mapper.Copy(model, dbItem);

                MainDbContext.Instance.News.Update(dbItem);
                MainDbContext.Instance.SaveChanges();
            }

            return this.RedirectToActionPermanent("Index");
        }
    }
}