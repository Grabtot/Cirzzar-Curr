using CirzzarCurr.Models;
using CirzzarCurr.Models.Enums;
using CirzzarCurr.Services;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;

namespace CirzzarCurr.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private IImageService _imageService;
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        private readonly ValueConverter<DateOnly, DateTime> _dateOnlyConverter = new(
              dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
              dateTime => DateOnly.FromDateTime(dateTime));



        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions, IImageService imageService)
            : base(options, operationalStoreOptions)
        {
            _imageService = imageService;
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


            ValueConverter<Image, string> imageConverter = new(
                   image => _imageService.EncodeImage(image),
                   encoded => _imageService.DecodeImage(encoded));

            builder.Entity<Product>()
                .Property(prod => prod.Image)
                .HasConversion(imageConverter);
            builder.Entity<Ingredient>()
                .Property(ing => ing.Image)
                .HasConversion(imageConverter);


            builder.Entity<Product>()
                .HasDiscriminator<ProductType>("ProductType")
                .HasValue<Pizza>(ProductType.Pizza);

        }
    }
}