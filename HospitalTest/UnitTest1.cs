using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.DataAccess;
using Hospital.Entities;
using ConsoleDbConnection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;

namespace HospitalTest
{
    [TestClass]
    public class UnitTest1
    {
        AppDbContext DbContext;
        [TestInitialize]
        public void Setup() {
            string[] Args = { "", "" };
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer("Server = DESKTOP-Q37JUD8; Database = ForStudying; Trusted_Connection = True", b => b.MigrationsAssembly("Infrastructure"));
             DbContext = new AppDbContext(options.Options);
        }
        [TestMethod]
        public void GetGpsByPatient()
        {
            string surname = "Smith";
            Repository<GP> gp = new Repository<GP>(DbContext);
            IGPRepository gPRepository = new GPRepository(DbContext);
            IReadOnlyList<GP> actual = gp.GetWithRawSql("SELECT distinct doctors.* FROM " +
                                          " dbo.GPs AS doctors, dbo.Regions AS regions, dbo.GPRegions AS gpregions, dbo.Patients AS patients WHERE " +
                                          $" doctors.Id = gpregions.GPId AND regions.Id = gpregions.RegionId AND gpregions.RegionId = patients.RegionId AND patients.Surname = '{surname}'; ").ToList();

            IReadOnlyList<GP> expected = gPRepository.GetGPsByPatientSurname(surname);
            Assert.AreEqual(expected.Count, actual.Count, "Wrond number of rows ");
        }
        [TestMethod]
        public void GetGPsByRegion()
        {
            string region = "Surrey";
            Repository <GP> gp = new Repository<GP>(DbContext);
            IGPRepository gPRepository = new GPRepository(DbContext);
            IReadOnlyList<GP> expected = gp.GetWithRawSql(
                    "SELECT " +
                        "gp.* "+
                        "FROM [dbo].GPs AS gp "+
                        "WHERE  EXISTS (SELECT " +
                            "1 AS [C1]  " +
                            "FROM [dbo].GPRegions AS gprg "+
                            $"WHERE (gp.[Id] = gprg.GPId) AND(gprg.RegionId = (Select dbo.Regions.Id from dbo.Regions where dbo.Regions.Name = '{region}')));"
                        ).ToList();
            IReadOnlyList<GP> actual = gPRepository.GetGpsByRegion(region).ToList();
            Assert.AreEqual(expected.Count, actual.Count, "The number of rows is wrong");
        }
        [TestMethod]
        public void GetRegionByGpsSurname()
        {
            string surname = "Liskov";
            Repository<Region> rg = new Repository<Region>(DbContext);
            IRegionRepository regionRepository = new RegionRepository(DbContext);
            IReadOnlyList<Region> expected = rg.GetWithRawSql("" +
                "SELECT " +
                "rg.* " +
                    "FROM dbo.Regions as rg " +
                    "WHERE  EXISTS " +
                    "( SELECT " +
                    "1 " +
                    "FROM dbo.GPRegions as gprg " +
                    "WHERE (rg.Id = gprg.RegionId) AND (gprg.GPId = " +
                    $"(SELECT dbo.GPs.Id from dbo.GPs WHERE dbo.GPs.Surname  = '{surname}')))").ToList();
            IReadOnlyList<Region> actual = regionRepository.GetRegionsByGpSurnane(surname);
            Assert.AreEqual(expected.Count, actual.Count, "Wrond number of rows ");
        }
        [TestMethod]
        public void GetRegionByPationsSurname()
        {
            string surname = "Stubbs";
            Repository<Region> rg = new Repository<Region>(DbContext);
            IRegionRepository regionRepository = new RegionRepository(DbContext);
            var expected = rg.GetWithRawSql("" +
                "SELECT " +
                    "rg.*" +
                        "FROM dbo.Regions as rg " +
                        "WHERE EXISTS " +
                        "(SELECT " +
                        "1 " +
                        "FROM dbo.Patients as patients " +
                        $"WHERE (rg.Id = patients.RegionId) AND (patients.Surname = '{surname}'));").ToList().FirstOrDefault();
            Region actual = regionRepository.GetRegionsByPatientsSurname(surname);
            Assert.AreEqual(expected,actual , "Wrond number of rows ");
        }
        [TestMethod]
        public void GetPatientByRegionName()
        {
            string name = "Norfolk";
            Repository<Patient> repository = new Repository<Patient>(DbContext);
            IPatientRepository patientRepository = new PatientRepository(DbContext);
            var expected = repository.GetWithRawSql("Select patients.* from dbo.Patients as patients, dbo.Regions " +
                                     $" where patients.RegionId = dbo.Regions.Id and dbo.Regions.Name = '{name}'; ").ToList();
            var actual = patientRepository.GetPatientsByRegionName(name);
            Assert.AreEqual(expected.Count, actual.Count, "Wrond number of rows ");
        }
        [TestMethod]
        public void GetPatientsByGpSurname()
        {
            string surname = "Liskov";
            Repository<Patient> repository = new Repository<Patient>(DbContext);
            IPatientRepository patientRepository = new PatientRepository(DbContext);
            var expected = repository.GetWithRawSql("select Patients.* from dbo.Patients as patients, dbo.GPs as gp, dbo.GPRegions as gprg, dbo.Regions as rg " +
                                                    $" where gp.Surname = '{surname}' and gp.Id = gprg.GPId and rg.Id = gprg.RegionId and Patients.RegionId = rg.Id; ").ToList();
            var actual = patientRepository.GetPatientsByGpSurname(surname);
            Assert.AreEqual(expected.Count, actual.Count, "Wrond number of rows ");

        }
    }
}
    