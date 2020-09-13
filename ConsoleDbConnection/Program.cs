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
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BooksStore;Trusted_Connection=True;", b => b.MigrationsAssembly("Infrastructure"));
            // optionsBuilder.UseMySql("server=localhost;Port=3306;Database=testdb;Uid=root;Pwd=0000;");
            return new AppDBContext(optionsBuilder.Options);
        }
    }   
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
                foreach(Patient gp in dBContext.Patients)
                {
                    Console.WriteLine(gp.Name);
                }
            }


        }
    }
}

