using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public int Id { get; set; }
    }
}