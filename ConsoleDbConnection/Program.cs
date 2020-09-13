using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Infrastructure.DataAccess;
using Hospital.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleDbConnection
{
    class Program
    {
       public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            using(AppDBContext dBContext = new AppDBContext(options))
            {
                /*dBContext.GPs.AddRange(
                    new GP("Tim", "Golubkin", "Yirevich", TimeSpan.Zero), new GP("John", "Brown",null,TimeSpan.Zero));
                dBContext.SaveChanges();*/
                foreach(GP gp in dBContext.GPs)
                {
                    Console.WriteLine(gp.Name);
                }
            }


        }
    }
}

