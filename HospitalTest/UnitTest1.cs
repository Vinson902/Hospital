using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var actual = gp.GetWithRawSql("SELECT doctors.*, patients.InsuranceNumber as Number FROM " +
                                          " dbo.GPs AS doctors, dbo.Regions AS regions, dbo.GPRegions AS gpregions, dbo.Patients AS patients WHERE " +
                                          " doctors.Id = gpregions.GPId AND regions.Id = gpregions.RegionId AND gpregions.RegionId = patients.RegionId AND patients.Surname = 'Borodkov'; ");
            IGPRepository gPRepository = new GPRepository(dbContext);
            var expected = gPRepository.GetGPsByPatient("Borodkov");
            Assert.AreEqual(expected.Single().Name, actual.Single().Name, "Account not debited correctly");
        }
    }
}
