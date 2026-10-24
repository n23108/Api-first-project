using System.ComponentModel.DataAnnotations;

namespace WEB_API
{
    public class Users
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
    public class UserLog
    {
        [Required]

        public string userName { get; set; }
        [Required]

        public string password { get; set; }


    }
}
