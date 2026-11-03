using Entities;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository
    {
        static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        public User AddUser(User user)
        {
            string path = "../Repositories/User.txt";
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return user;
        }

        public User GetUser(LoginUser logInUser)
        {
            string path = "../Repositories/User.txt";
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile, JsonOptions);
                    if (user.UserName == logInUser.UserName && user.Password == logInUser.Password)
                        return user;
                }
            }
            return null;
        }
        public User GetUserById(int id)
    {
           string path = "../Repositories/User.txt";
           using (StreamReader reader = System.IO.File.OpenText(path))
        {
           string? currentUserInFile;
           while ((currentUserInFile = reader.ReadLine()) != null)
        {
            User user = JsonSerializer.Deserialize<User>(currentUserInFile, JsonOptions);
            if (user.Id == id)
                return user;
        }
       }
          return null;
    }
        public void UpdateUser(int id, User updateUserDetails)
        {
            string path = "../Repositories/User.txt";
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile, JsonOptions);
                    if (user.Id == id)
                    {
                            textToReplace = currentUserInFile;
                            break;
                    }
                
                }
            }

            if (textToReplace != string.Empty)
            {
                updateUserDetails.Id = id;
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(updateUserDetails));
                System.IO.File.WriteAllText(path, text);
            }
            
        }
    }
}

