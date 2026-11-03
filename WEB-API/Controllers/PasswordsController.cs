using Microsoft.AspNetCore.Mvc;
using Zxcvbn;
namespace WEB_API.Controllers
{
    //fix: A controller class name ends with Controller, and types are written in PascalCase. The route stays api/passwords
    //fix: The file is renamed to PasswordsController.cs, so it matches the class
    public class PasswordsController : Controller
    {
        [Route("api/[controller]")]
        [HttpPost]
        public ActionResult Post([FromBody] string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }

            var result = Core.EvaluatePassword(password);
            int score = result.Score;
            if (score < 2)
            {
                return Ok(new
                {
                    isValid = false,
                    score = score,
                    message = "הסיסמה חלשה מדי (פחות מ-2)"
                });
            }
            return Ok(new
            {
                isValid = true,
                score = score,
                message = "הסיסמה חזקה מספיק"
            });



        }
    }
}

