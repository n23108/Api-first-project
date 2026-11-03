using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        UsersService usersService = new UsersService();
        // GET: api/<User>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "something";
        }
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            user=usersService.AddUser(user);
            return CreatedAtAction(nameof(Get),new { id = user.id },user);
        }

        [HttpPost("Login")]

        public ActionResult<UserLog> PostLog([FromBody] UserLog loginUser)
        {
            var user= usersService.GetUser(loginUser);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User userToUpdate)
        {
          usersService.UpdateUser(id, userToUpdate);
            return Ok();
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
