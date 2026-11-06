using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Required]
        public string userName { get; set; }
        [Required]

        public string firstName { get; set; }
        [Required]

        public string lastName { get; set; }
        [Required]

        public string password { get; set; }
        public int id { get; set; }
    }
}
