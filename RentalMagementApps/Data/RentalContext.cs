using Microsoft.EntityFrameworkCore;
using RentalManagementApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementApps.Data
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Kost> Kost { get; set; }
        public DbSet<Room> Room { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasIndex(b => b.EmailAddress)
                                .IsUnique();
            modelBuilder.Entity<Kost>().ToTable("Kost");
            modelBuilder.Entity<Room>().ToTable("Room");
        }



    }
}
