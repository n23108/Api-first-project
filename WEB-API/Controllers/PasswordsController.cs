using Microsoft.AspNetCore.Mvc;
using Services;

namespace WEB_API.Controllers
{
    public class PasswordsController : Controller
    {
        private PasswordsService passwordsService = new PasswordsService();

        [Route("api/[controller]")]
        [HttpPost]
        public ActionResult Post([FromBody] string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }

            var result = passwordsService.EvaluatePassword(password);

            return Ok(result);
        }
    }
}

