namespace Server.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Document
    {
        [Key]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public string Path { get; set; }

        public DateTime FirstUploaded { get; set; }

        public DateTime LastEdited { get; set; }
    }
}