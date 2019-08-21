using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using webshop.Models;

namespace webshop.Data
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private ApplicationDbContext context;
 
        public ApplicationUserManager(ApplicationDbContext context, IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.context = context;
        }

        public override Task<IdentityResult> CreateAsync(ApplicationUser user)
        {

            var result = base.CreateAsync(user);
            if (result.Result.Succeeded)
            {
                var newUser = FindByNameAsync(user.UserName).Result;
                var customer = new Customer();
                customer.UserId = newUser.Id;
                var changeTracking = this.context.Customers.Add(customer);
                context.SaveChanges();
                if (changeTracking.IsKeySet)
                {
                    newUser.CustomerId = changeTracking.Entity.Id;
                }
                else
                {
                    throw new ApplicationException();
                }


            }
            return result;
        }

        //public async Task<string> GetNameAsync(ClaimsPrincipal principal)
        //{
        //    var user = await GetUserAsync(principal);
        //    return user.Name;
        //}
    }
}
