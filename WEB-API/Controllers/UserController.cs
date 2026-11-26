using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IPasswordsService _passwordsService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUsersService usersService, IPasswordsService passwordsService, ILogger<UserController> logger)
        {
            _usersService = usersService;
            _passwordsService = passwordsService;
            _logger = logger;
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
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            var result = _passwordsService.EvaluatePassword(user.Password);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            await _usersService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> PostLog([FromBody] LoginUser loginUser)
        {
            var user = await _usersService.GetUser(loginUser);
            if (user == null)
            {
                return NoContent();
            }

            _logger.LogInformation($"User {user.UserName} logged in successfully. first name:{user.FirstName}, last name:{user.LastName}");
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            var result = _passwordsService.EvaluatePassword(userToUpdate.Password);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            await _usersService.UpdateUser(id, userToUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}