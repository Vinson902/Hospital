using Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataAccess
{
   public class AppDBContext : DbContext
    {
        public DbSet<GP> GPs { get; set; }
        public DbSet<GpRegion> GPRegions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Region> Regions { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) :base (options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GpRegion>()
                .HasKey(t => new { t.GPId, t.RegionId });

            modelBuilder.Entity<GpRegion>()
                .HasOne(sc => sc.GP)
                .WithMany(s => s.GpRegions)
                .HasForeignKey(sc => sc.GPId);

            modelBuilder.Entity<GpRegion>()
                .HasOne(sc => sc.Region)
                .WithMany(c => c.GPRegions)
                .HasForeignKey(sc => sc.RegionId);
        }
    }
}
