using CarPool.Data.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CarPool.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DBBookedRide> BookedRides { get; set; }
        public DbSet<DBOfferRide> OfferRides { get; set; }
        public DbSet<DBUser> Users { get; set; }
        public DbSet<IntermediaryStop> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var cities = new List<IntermediaryStop>
            {
                new IntermediaryStop { Id = Guid.NewGuid().ToString(), Name = "Cincinnati" },
                new IntermediaryStop { Id = Guid.NewGuid().ToString(), Name = "Madinson" },
                new IntermediaryStop { Id = Guid.NewGuid().ToString(), Name = "Indianapolis"},
                new IntermediaryStop { Id = Guid.NewGuid().ToString(), Name = "Chicago"},
            };

            modelBuilder.Entity<IntermediaryStop>().HasData(cities);
        }
    }
}
