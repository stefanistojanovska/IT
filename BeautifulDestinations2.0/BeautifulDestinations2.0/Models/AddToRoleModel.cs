using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautifulDestinations2._0.Models
{
    public class AddToRoleModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> roles { get; set; }
    }
}