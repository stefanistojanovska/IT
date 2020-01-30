using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeautifulDestinations2._0.Models
{
    public class Review
    {
        [Key]
        public int id { get; set; }

        public int Destination { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        [Range(1, 5, ErrorMessage = "The rating must be between 1-5")]
        public int Rating { get; set; }
        public string userEmail { get; set; }
    }
}