namespace Server.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Event
    {
        public const int TypeUndefined = 0;
        public const int TypeAction = 0;
        public const int TypeDevotion = 0;

        [Key]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }

        public bool IsPublic { get; set; }
    }
}