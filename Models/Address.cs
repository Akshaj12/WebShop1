using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webshop.Models
{
 //   [Owned]
    public class Address
    {
      public int Id { get; set; }
      public string FullName { get; set; }
      public string CO { get; set; }
      public string Street { get; set; }
      [DataType(DataType.PostalCode)]
      public int PostalCode { get; set; }
      public string City { get; set; }
      public string State { get; set; }
      public string Country { get; set; }
    }
}