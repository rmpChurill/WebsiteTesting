namespace Server.Models
{
    using System.ComponentModel.DataAnnotations;

    public class NewsletterSubscription
    {
        [Key]
        public long Id { get; set; }

        public string Mail { get; set; }
    }
}