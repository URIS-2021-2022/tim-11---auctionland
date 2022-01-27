using Microsoft.AspNetCore.Mvc;
using UserService.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDbContext db;
        public UserController() 
        {
            db = new UserDbContext();
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            try 
            {
                db.Users.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserUpdate model)
        {
            var temp = new User();
            temp = db.Users.Find(id);
                if(model.Name!=null)
                    temp.Name = model.Name;
                if (model.LastName != null)
                     temp.LastName = model.LastName;
                if (model.UserName != null)
                     temp.UserName = model.UserName;
                if (model.Password != null)
                    temp.Password = model.Password;
                if (model.Type != null)
                    temp.Type = model.Type;
            db.Users.Update(temp);
            db.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, temp);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var temp = new User() { UserId = id };
            db.Users.Remove(temp);
            db.SaveChanges();
        }
    }
}
