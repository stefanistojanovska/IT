using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautifulDestinations2._0.Models
{
    public class DestRevViewModel
    {
        public Destination destination{ get; set; }
        public Review review { get; set; }
        public List<Review> reviews { get; set; }

    }
}