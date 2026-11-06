using Microsoft.AspNetCore.Mvc;
using Services;

namespace WEB_API.Controllers
{
    public class PasswordsController : Controller
    {
        private IPasswordsService _passwordsService;
        public PasswordsController(IPasswordsService passwordsService)
        {
            _passwordsService = passwordsService;
        }

        [Route("api/[controller]")]
        [HttpPost]
        public ActionResult Post([FromBody] string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }

            var result = _passwordsService.EvaluatePassword(password);

            return Ok(result);
        }
    }
}

