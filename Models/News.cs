namespace Server.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public class News
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationTime { get; set; }
    }
}