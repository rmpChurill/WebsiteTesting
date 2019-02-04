namespace Server.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public EventType Type { get; set; }

        public String TypeIntern
        {
            get
            {
                return this.Type.ToString();
            }

            set
            {
                this.Type = Enum.Parse<EventType>(value);
            }
        }

        [NotMapped]
        public Visibility Visibility { get; set; }

        public string VisibilityIntern
        {
            get
            {
                return this.Visibility.ToString();
            }
            set
            {
                this.Visibility = Enum.Parse<Visibility>(value);
            }
        }

        public DateTime CreationTime { get; set; }

        public DateTime LastEditedTime { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}