using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webshop.Models
{

    public class ApplicationUser : IdentityUser
    {
      public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
      public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
      public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
      public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }

      public string FirstName { get; set; }
      public string LastName { get; set; }
      
      public int CustomerId { get; set; }
      public Customer Customer { get; set; }
    }

    public class Customer
    {
      public int Id { get; set; }
      [ForeignKey("User")]
      public string UserId { get; set; }
      public ApplicationUser User { get; set; }
      [ForeignKey("SavedAddress")]
      public int SavedAddressId { get; set; }
      public Address SavedAddress { get; set; }
      public ICollection<Order> Orders { get; set; }
      //public ICollection<Product> FavoriteProducts { get; set; }
      //public Cart Cart { get; set; }
    }
}
