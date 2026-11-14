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
        IPasswordsService _passwordsService;

        public UserController(IUsersService usersService, IPasswordsService passwordsService)
        {
            _usersService = usersService;
            _passwordsService = passwordsService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        //Why is GET by id not implemented? The assignment asks it to return the user with this id (or NoContent if there is none)
        public string Get(int id)
        {
            return "something";
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            var result = _passwordsService.EvaluatePassword(user.Password);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }

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
            var result = _passwordsService.EvaluatePassword(userToUpdate.Password);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            _usersService.UpdateUser(id, userToUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}