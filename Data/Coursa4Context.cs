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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public Coursa4Context() 
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
            // Конфигурация клиента
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.LastName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(c => c.Email).HasMaxLength(100);
                entity.HasIndex(e => e.PhoneNumber).IsUnique();

                // Связи
                entity.HasMany(c => c.Vehicles)
                      .WithOne(v => v.Client)
                      .HasForeignKey(v => v.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(c => c.Orders)
                      .WithOne(o => o.Client)
                      .HasForeignKey(o => o.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Конфигурация для авто
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

                // Связи
                entity.HasOne(v => v.Client)
                      .WithMany(c => c.Vehicles)
                      .HasForeignKey(v => v.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Order>()
                      .WithOne(o => o.Vehicle)
                      .HasForeignKey(o => o.VehicleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Конфигурация сотрудника
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Specialization).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            });

            // Конфигурация заказа
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.AcceptionDate).IsRequired();
                entity.Property(e => e.EstimatedCompletionDate).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");

                // Связи
                entity.HasOne(o => o.Client)
                      .WithMany(c => c.Orders)
                      .HasForeignKey(o => o.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.Vehicle)
                      .WithMany()
                      .HasForeignKey(o => o.VehicleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Конфигурация услуги
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.RequiredSpecialization).IsRequired().HasMaxLength(100);
            });
            // Конфигурация аккаунта
            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(15);
                entity.Property(c => c.Login).IsRequired().HasMaxLength(20);
                entity.Property(c => c.PasswordHash).IsRequired();
            });
        }
    }
}
