﻿using CirzzarCurr.Models;
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
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }

        private readonly ValueConverter<DateOnly, DateTime> _dateOnlyConverter = new(
              dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
              dateTime => DateOnly.FromDateTime(dateTime));




#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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


        }
    }
}