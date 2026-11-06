using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "something";
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            user = _usersService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPost("Login")]
        public ActionResult<User> PostLog([FromBody] LoginUser loginUser)
        {
            var user = _usersService.GetUser(loginUser);
            if (user == null)
            {
                return NoContent();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User userToUpdate)
        {
            _usersService.UpdateUser(id, userToUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}