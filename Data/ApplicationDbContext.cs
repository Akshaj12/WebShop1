using webshop.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>(b =>
        {
            // Each User can have many UserClaims
            b.HasMany(c => c.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            b.HasMany(c => c.Logins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            b.HasMany(c => c.Tokens)
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany(c => c.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            
            b.HasOne(c => c.Customer);
        });

        modelBuilder.Entity<Customer>(b =>
        {
          b.HasOne(c => c.User);
          b.HasOne(c => c.SavedAddress);
        });

        modelBuilder.Entity<Order>(b =>
        {
            b.HasOne(o => o.Customer);
            b.HasOne(o => o.BillingAddress);
            b.HasOne(o => o.DeliveryAddress);
            b.HasMany(o => o.Products);
        });

        modelBuilder.Entity<OrderItem>(b =>
        {
            b.HasKey(o => new { o.OrderId, o.ProductId});
        });

        modelBuilder.Entity<Category>(b =>
        {
            b.HasMany(c => c.SubCategories).WithOne().HasForeignKey(c => c.ParentCategoryId);
            b.HasMany(c => c.Products).WithOne().HasForeignKey(pc => pc.CategoryId);
        });
        modelBuilder.Entity<Category>().HasData(
          new Category() { CategoryId = 1, CategoryName = "Categories" }
        );

        modelBuilder.Entity<ProductCategory>(b =>
        {
            b.HasKey(pc => new { pc.CategoryId, pc.ProductId});
        });
    }
  }
}
