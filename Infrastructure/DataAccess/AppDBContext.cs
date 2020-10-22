using Hospital.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataAccess
{
   public class AppDbContext : DbContext
    {
        public DbSet<GP> GPs { get; set; }
        public DbSet<GpRegion> GPRegions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Region> Regions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) :base (options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            
        }
       /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var patients = new[]
               {
                 new Patient("Vitaliy","Borodkov","Sergeevich","0000000001"){Id = 1,RegionId = 1},
                 new Patient("Michael","Smith","","0000000002") {Id =2, RegionId=2},
                 new Patient("Marek","Stubbs","","0000000003"){Id=3,RegionId = 3},
                 new Patient("Caolan","Dodson","","0000000004"){Id=4,RegionId = 4},
                 new Patient("Mai","Bateman","","0000000005"){Id=5,RegionId = 2},
                 new Patient("Kylan","Churchill","","0000000006"){Id=6,RegionId = 3},
                 new Patient("John-Paul","Bernard","","0000000007"){Id=7,RegionId = 4},
                 new Patient("Zavier","French","","0000000008"){Id=8,RegionId = 1},
                 new Patient("Melanie","Simmons","","0000000009"){Id=9,RegionId = 2},
                 new Patient("Romana","Anthony","","0000000010"){Id=10,RegionId = 3},
                 new Patient("Ezekiel","Neale","","0000000011"){Id=11,RegionId = 4},
                 new Patient("Rhiannon","Carlson","","0000000012"){Id=12,RegionId = 2},
                 new Patient("Carlton","Hyde","","0000000013"){Id=13,RegionId = 3},
                 new Patient("Hashir","Rooney","","0000000014"){Id=14,RegionId = 1},
                 new Patient("Kailum","Phelps","","0000000015"){Id=15,RegionId = 4},
                 new Patient("Alara","Fountain","","0000000016"){Id=16,RegionId = 4},
                 new Patient("Jorge","Waller","","0000000017"){Id=17,RegionId = 3},
                 new Patient("Herman","Oconnor","","0000000018"){Id=18,RegionId = 3},
                 new Patient("Elisa","Rodgers","","0000000019"){Id=19,RegionId = 2},
                 new Patient("Ifrah","Herbert","","0000000020"){Id=20,RegionId = 1},
                 new Patient("Laila","Tyler","","0000000021"){Id=21,RegionId = 1},

                };
            var regions = new[]
            {
                    new Region ("Surrey"){Id = 1},
                    new Region ("Wiltshire"){Id = 2},
                    new Region("Norfolk"){Id = 3},
                    new Region("Sussex"){Id = 4}

            };

            var gps = new []{
                new GP("Barbara","Liskov",""){Id = 1},
                new GP("Florence","Nightingale",""){Id = 2},
                new GP("Sigmund","Freud",""){Id = 3},
                new GP("Joseph","Lister",""){Id = 4}
            };
            var gpRegion = new[]
            {
                new GpRegion(){GPId = 1, RegionId = 1},
                new GpRegion(){GPId = 2, RegionId = 2},
                new GpRegion(){GPId = 3, RegionId = 3},
                new GpRegion(){GPId = 4, RegionId = 3},
                new GpRegion(){GPId = 3, RegionId = 2},
                new GpRegion(){GPId = 1, RegionId = 4},
            };


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

            modelBuilder.Entity<Region>().HasData(regions);
            modelBuilder.Entity<GP>().HasData(gps);
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<GpRegion>().HasData(gpRegion);
        }
    }
}
