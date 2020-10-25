using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Hospital.Entities;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hospital_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patients;


        public PatientController(AppDbContext dbContext)
        {
            _patients = new PatientRepository(dbContext);
        }

        [HttpGet]
        public async Task<IReadOnlyList<Patient>> Get()
        {
            return await _patients.GetAllAsync();
        }
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<Patient> GetbyId(int id)
        {
            return await _patients.GetByIdAsync(id);
        }
        [Route("[action]/{surname}")]
        [HttpGet]
        public async Task<IReadOnlyList<Patient>> GetByGpSurname(string surname)
        {
            return await _patients.GetPatientsByGpSurnameAsync(surname);
        }
        [Route("[action]/{name}")]
        [HttpGet]
        public async Task<IReadOnlyList<Patient>> GetByRegionName(string name)
        {
            return await _patients.GetPatientsByRegionNameAsync(name);
        }
        [HttpPost]
        public void Post(Patient patient)
        {
            _patients.Add(patient);
        }
    }
}
