using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Entities;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _region;

        public RegionController(AppDbContext dbContext)
        {
            _region = new RegionRepository(dbContext);
        }
        [HttpGet]
        public async Task<IReadOnlyList<Region>> GetAll()
        {
            return await _region.GetAllAsync();
        }

        // GET api/<RegionController>/5
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<Region> GetById(int id)
        {
            return await _region.GetByIdAsync(id);
        }
        [Route("[action]/{surname}")]
        [HttpGet]
        public async Task<Region> GetReByPatientsSurname(string surname)
        {
            return await _region.GetRegionsByPatientsSurnameAsync(surname);
        }
        [Route("[action]/{surname}")]
        [HttpGet]
        public async Task<IReadOnlyList<Region>> GetByGpSurname(string surname)
        {
            return await _region.GetRegionsByGpSurnameAsync(surname);
        }


        // POST api/<RegionController>
        [HttpPost]
        public void Post(Region region)
        {
            _region.Add(region);
        }

        // PUT api/<RegionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
