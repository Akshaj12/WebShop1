using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
