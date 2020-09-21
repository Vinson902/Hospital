using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;
using Infrastructure.DataAccess;
using Hospital.Entities;
using ConsoleDbConnection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HospitalTest
{
    [TestClass]
    public class UnitTest1
    {
        public void Setup() {
        }
        [TestMethod]
        public void TestMethod1()
        { 
            string[] Args = {"","" };
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer("Server = DESKTOP-Q37JUD8; Database = ForStudying; Trusted_Connection = True", b => b.MigrationsAssembly("Infrastructure"));
            AppDbContext dbContext = new AppDbContext(options.Options);
            Repository<GP> gp = new Repository<GP>(dbContext);
            var actual = gp.GetWithRawSql($"Select * from dbo.GPs where Name = 'Barbara' ");
            var expected = gp.Get(gp => gp.Name == "Barbara");
            Assert.AreEqual(expected.Single().Name, actual.Single().Name, "Account not debited correctly");
        }
    }
}
