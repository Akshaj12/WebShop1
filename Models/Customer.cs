using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webshop.Models
{
    public class Customer : IdentityUser
    {
      public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
      public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
      public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
      public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }

      public string FirstName { get; set; }
      public string LastName { get; set; }
      public Address HomeAddress { get; set; }
      public ICollection<Order> Orders { get; set; }
      public ICollection<Product> FavoriteProducts { get; set; }
      //public Cart Cart { get; set; }
    }
}
