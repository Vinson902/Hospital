using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hospital.Entities;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Hospital_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GPController : ControllerBase
    {
        private readonly IGPRepository _doctors;
        public GPController(AppDbContext dbContext)
        {
            _doctors = new GPRepository(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGP()
        {
            var doctors = await _doctors.GetAllAsync();
            return Ok(doctors);
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<GP> Get(int id)
        {
            return await _doctors.GetByIdAsync(id);
        }
       
        [Route("[action]/{name}")]
        [HttpGet]
        public async Task<IReadOnlyList<GP>> GetByRegionName(string name)
        {
            return await _doctors.GetGpsByRegionAsync(name);
        }

        [Route("[action]/{surname}")]
        [HttpGet]
        public async Task<IReadOnlyList<GP>> GetByPatientSurname(string surname)
        {
            return await _doctors.GetGPsByPatientSurnameAsync(surname);
        }

        [HttpPost]
        public void Post(GP gp)
        {
            Thread.Sleep(8000);
            _doctors.Add(gp);
        }
    }
}
