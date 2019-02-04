namespace Server.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class MainDbContext : DbContext
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

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<NewsletterSubscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=main.db");
        }
    }
}