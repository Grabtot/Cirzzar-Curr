using CirzzarCurr.Models;
using CirzzarCurr.Models.Cart;
using CirzzarCurr.Models.Enums;
using CirzzarCurr.Models.Products;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;

namespace CirzzarCurr.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }

        private readonly ValueConverter<DateOnly, DateTime> _dateOnlyConverter = new(
              dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
              dateTime => DateOnly.FromDateTime(dateTime));




#pragma warning disable CS8618 
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
#pragma warning restore CS8618 
            : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(u => u.BirthDay)
                .HasConversion(_dateOnlyConverter);
            builder.Entity<ApplicationUser>()
                .Property(u => u.RegistrationDate)
                .HasConversion(_dateOnlyConverter);

            builder.Entity<Product>()
                .HasDiscriminator<ProductType>("ProductType")
                .HasValue<Pizza>(ProductType.Pizza)
                .HasValue<Dessert>(ProductType.Dessert)
                .HasValue<Beverage>(ProductType.Beverage);

            builder.Entity<CartItem>()
                .HasDiscriminator<ProductType>("ProductType")
                .HasValue<PizzaCartItem>(ProductType.Pizza)
                .HasValue<CartItem>(ProductType.Dessert)
                .HasValue<CartItem>(ProductType.Beverage);

            builder.Entity<ApplicationUser>()
          .HasMany(u => u.Cart)
          .WithOne()
          .IsRequired()
          .OnDelete(DeleteBehavior.Cascade);
        }

        public override int SaveChanges()
        {
            var entitiesWithProductType = ChangeTracker.Entries<CartItem>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity);

            foreach (var entity in entitiesWithProductType)
            {
                if (entity.Product != null)
                {
                    entity.ProductType = entity.Product.Type;
                }
            }

            return base.SaveChanges();
        }
    }
}