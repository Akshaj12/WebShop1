using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class Cart
    { //Consider only storing the Cart in the user session for now
        public int Id { get; set; }
        public ICollection<CartProduct> Contents;
        
    }

    public class CartProduct
    { //Join entity
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int Quantity { get; set; }
    }
}
