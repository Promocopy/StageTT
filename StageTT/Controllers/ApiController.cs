using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StageTT.Data;
using StageTT.Entity;

namespace StageTT.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class apiController : ControllerBase
    {
        private readonly PersonContext _context;
        public apiController(PersonContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _context.person.FirstOrDefault(c => c.Id==id);
                if (user==null)
                {
                    return NotFound("No user found");
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
        }

        [HttpPost]
        public IActionResult post(PersonRequest id)
        {
            Person user = new Person();
            user.Name = id.Name;
            try
            {
                _context.person.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult put(int id, Person idf)
        {
            if (id!=idf.Id)
            {
                return BadRequest("Not found");
            }
            var user = _context.person.Find(id);
            if (user==null)
            {
                return NotFound("User not found");
            }
            user.Name = idf.Name;
            try
            {
                _context.person.Update(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            try
            {
                var user = _context.person.FirstOrDefault(c => c.Id==id);
                if (user==null)
                {
                    return NotFound("No user found");
                }
                _context.person.Remove(user);
                _context.SaveChanges();
                return Ok(user);
            }

            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }

        }

        [HttpGet]
        public IActionResult results()
        {
            return Ok("This api is active");
        }
    }
}
