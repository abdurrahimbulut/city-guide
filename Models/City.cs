using System;
using System.Collections.Generic;

namespace cityGuide.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public List<Comment> Comment { get; set; }
    }
}