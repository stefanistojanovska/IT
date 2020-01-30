using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautifulDestinations2._0.Models
{
    public class Favourites
    {
        [Key]
        public int Id { get; set; }
        public int Destination { get; set; }
        public string userEmail { get; set; }
    }
}