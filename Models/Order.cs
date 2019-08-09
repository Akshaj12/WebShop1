using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class Order
    {
      public int Id { get; set; }
      public OrderStatus Status { get; set; }
      public Customer Customer { get; set; }
      public Address DeliveryAddress { get; set; }
      public Address BillingAddress { get; set; }
      [DataType(DataType.Date)]
      public DateTime OrderTime { get; set; }


      public ICollection<OrderProduct> Products { get; set; }
    }

    public class OrderProduct
    { //join entity
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public enum OrderStatus
    {
      TO_BE_PAID,
      TO_BE_PACKAGED,
      TO_BE_SHIPPED,
      SHIPPING,
      DELIVERED,
    }
}
