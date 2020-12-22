using System.Collections.Generic;

namespace cityGuide.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public ICollection<Comment> Comment { get; set; }
        public string Role { get; set; }

    }
}