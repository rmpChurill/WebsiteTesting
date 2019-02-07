namespace Server.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            this.IsOperator = false;
            this.IsAdmin = false;
            this.CanCreateNews = false;
            this.CanCreateEvents = false;
            this.CanCreateInternals = false;
            this.CanSeeInternals = false;
        }

        public bool ReceiveNewsletter {get;set;}

        public bool IsOperator { get; set; }

        public bool IsAdmin { get; set; }

        public bool CanCreateNews { get; set; }

        public bool CanCreateEvents { get; set; }

        public bool CanCreateInternals { get; set; }

        public bool CanSeeInternals { get; set; }
    }
}