namespace Server.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class MainDbContext : IdentityDbContext<User>
    {
        private static MainDbContext instance;

        public static MainDbContext Instance
        {
            get
            {
                if (MainDbContext.instance == null)
                    MainDbContext.instance = new MainDbContext();

                return MainDbContext.instance;
            }
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<NewsletterSubscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=main.db");
        }
    }
}