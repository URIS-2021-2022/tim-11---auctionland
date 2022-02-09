using Microsoft.AspNetCore.Mvc;
using ParcelService.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParcelService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        ParcelDbContext db;

        public ParcelController()
        {
            db = new ParcelDbContext();
        }
        // GET: api/<ParcelController>
        [HttpGet]
        public IEnumerable<Parcel> Get()
        {
            return db.Parcels.ToList();
        }

        // GET api/<ParcelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ParcelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ParcelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParcelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
