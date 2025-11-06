using coursa4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursa4.Data
{
    internal class Coursa4Context: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CarPart> CarParts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public void ApplicationContext() 
        { 
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AutoServiceDB;Username=postgres;Password=Kukavruka");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Client configuration
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.LastName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(c => c.Email).HasMaxLength(100);
                entity.HasIndex(e => e.PhoneNumber).IsUnique();

                // Relationships
                entity.HasMany(c => c.Vehicles)
                      .WithOne(v => v.Client)
                      .HasForeignKey(v => v.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(c => c.Orders)
                      .WithOne(o => o.Client)
                      .HasForeignKey(o => o.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Vehicle configuration
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Brand).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.VIN).IsRequired().HasMaxLength(17);
                entity.Property(e => e.LicensePlate).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Mileage).IsRequired();

                entity.HasIndex(e => e.VIN).IsUnique();
                entity.HasIndex(e => e.LicensePlate).IsUnique();

                // Relationships
                entity.HasOne(v => v.Client)
                      .WithMany(c => c.Vehicles)
                      .HasForeignKey(v => v.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Order>()
                      .WithOne(o => o.Vehicle)
                      .HasForeignKey(o => o.VehicleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Employee configuration
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Specialization).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);

                // Relationships
                entity.HasMany(e => e.Orders)
                      .WithOne(o => o.Employee)
                      .HasForeignKey(o => o.EmployeeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Order configuration
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.AcceptionDate).IsRequired();
                entity.Property(e => e.EstimatedCompletionDate).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");

                // Relationships
                entity.HasOne(o => o.Client)
                      .WithMany(c => c.Orders)
                      .HasForeignKey(o => o.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.Vehicle)
                      .WithMany()
                      .HasForeignKey(o => o.VehicleId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.Employee)
                      .WithMany(e => e.Orders)
                      .HasForeignKey(o => o.EmployeeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Service configuration
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");

                // Связь с Order удалена, так как у Service больше нет OrderId и Order

                // Many-to-many relationship with CarPart
                entity.HasMany(s => s.CarParts)
                      .WithMany()
                      .UsingEntity<Dictionary<string, object>>(
                          "ServiceCarPart",
                          j => j
                              .HasOne<CarPart>()
                              .WithMany()
                              .HasForeignKey("CarPartId")
                              .OnDelete(DeleteBehavior.Cascade),
                          j => j
                              .HasOne<Service>()
                              .WithMany()
                              .HasForeignKey("ServiceId")
                              .OnDelete(DeleteBehavior.Cascade));
            });

            // CarPart configuration
            modelBuilder.Entity<CarPart>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Price).IsRequired().HasColumnType("decimal(18,2)"); 
                entity.Property(c => c.QuantityInStock).IsRequired();
            });
        }
    }
}
