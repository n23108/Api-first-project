using Microsoft.AspNetCore.Mvc;
using Zxcvbn;
namespace WEB_API.Controllers
{
    public class passwords : Controller
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

