using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class Customer : ApplicationUser
    {


        public ICollection<Order> Orders { get; set; }
        public Cart Cart { get; set; }


    }
}
