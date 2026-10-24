using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        // GET: api/<User>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user =
                    JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.id == id)
                        return Ok(user);
                }
            }
            return NoContent();
        }
        static string FilePath = "User.txt";
        // POST api/<User>
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get),new { id = user.id },user);
        }

        [HttpPost("Login")]

        public ActionResult<UserLog> PostLog([FromBody] UserLog loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserLog user =
                    JsonSerializer.Deserialize<UserLog>(currentUserInFile);
                    if (user.userName == loginUser.userName && user.password == loginUser.password)
                        return Ok(loginUser);
                }
            }

            return NotFound();
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(FilePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user =
                    JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if(textToReplace != string.Empty)
{
                string text = System.IO.File.ReadAllText(FilePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(FilePath, text);
            }
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
