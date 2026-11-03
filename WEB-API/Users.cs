using System.ComponentModel.DataAnnotations;

namespace WEB_API
{
    //This class is one user, so a singular name is clearer: User
    //In C#, public properties are written in PascalCase (UserName, FirstName, LastName, Password, Id).
    //If you rename them, User.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
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
    //Each class goes in its own file, named after the class (UserLog.cs). A clearer name would be LoginUser.
    //Properties in PascalCase here too (UserName, Password)
    public class UserLog
    {
        [Required]

        public string userName { get; set; }
        [Required]

        public string password { get; set; }


    }
}
