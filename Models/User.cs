namespace Server.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public string Name { get; set; }

        public string Mail { get; set; }

        public bool IsOperator { get; set; }

        public bool CanCreateNews { get; set; }

        public bool CanCreateEvents { get; set; }

        public bool CanCreateInternals { get; set; }

        public bool CanSeeInternals { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}