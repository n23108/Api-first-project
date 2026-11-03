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
       public ActionResult<User> Get(int id)
    {
       var user = usersService.GetUserById(id);
       if (user == null)
      {
        return NoContent();
      }

      return Ok(user);
    }
        
        public ActionResult<User> Post([FromBody] User user)
        {
            user=usersService.AddUser(user);
            return CreatedAtAction(nameof(Get),new { id = user.Id },user);
        }

        [HttpPost("Login")]

       public ActionResult<User> PostLog([FromBody] LoginUser loginUser){
            var user= usersService.GetUser(loginUser);
            if(user == null)
            {
                return NoContent();
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
