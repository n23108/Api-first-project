using Entities;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public User AddUser(User user)
        {
            string path = "../Repositories/User.txt";
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return user;
        }

        public User GetUser(UserLog logInUser)
        {
            string path = "../Repositories/User.txt";
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userName == logInUser.userName && user.password == logInUser.password)
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
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(updateUserDetails));
                System.IO.File.WriteAllText(path, text);
            }
        }
    }
}

