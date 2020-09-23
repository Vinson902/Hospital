using Microsoft.EntityFrameworkCore;
using System;
using Infrastructure.DataAccess;
using Hospital.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;


namespace ConsoleDbConnection
{
    /* public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
     {
         public AppDbContext CreateDbContext(string[] args)
         {
             /*var builder = new ConfigurationBuilder();
             builder.SetBasePath(Directory.GetCurrentDirectory());
             builder.AddJsonFile("appsettings.json");
             var config = builder.Build();
             string connectionString = config.GetConnectionString("DefaultConnection");

             var connection =
     System.Configuration.ConfigurationManager.
     ConnectionStrings["DefaultConnection"].ConnectionString;

             var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
             var options = optionsBuilder
                 .UseSqlServer("Server=DESKTOP-Q37JUD8;Database=ForStudying;Trusted_Connection=True", m=>m.MigrationsAssembly("Infrastructure"))
                 .Options;

             return new AppDbContext(optionsBuilder.Options);
         }
     }   */
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connection =
    System.Configuration.ConfigurationManager.
    ConnectionStrings["DefaultConnection"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("Infrastructure"));
            // optionsBuilder.UseMySql("server=localhost;Port=3306;Database=testdb;Uid=root;Pwd=0000;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
    class Program
    {
       public static void Main(string[] args)
        {
            var DBFactory = new AppDbContextFactory();
            using (AppDbContext dBContext = DBFactory.CreateDbContext(args))
            {
                Region region = dBContext.Regions.Where(a => a.Id == 1).Single();
                foreach (Patient patients in dBContext.Patients.Where(a => a.RegionId == 1))
                {
                    Console.WriteLine($"{patients.Name} {patients.Surname} lives in Region {region.Name}");
                }
            }


        }
    }
}

