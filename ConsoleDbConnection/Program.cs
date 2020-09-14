using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Infrastructure.DataAccess;
using Hospital.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleDbConnection
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
           
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
               
                foreach(Patient gp in dBContext.Patients)
                {
                    Console.WriteLine(gp.Name);
                }
            }


        }
    }
}

