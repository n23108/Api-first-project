using Entities;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly string FilePath = "../Repositories/User.txt";
        private static readonly JsonSerializerOptions ReadOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public User AddUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson + Environment.NewLine);
            return user;
        }

        public User GetUser(LoginUser loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile, ReadOptions);
                    if (user.UserName == loginUser.UserName && user.Password == loginUser.Password)
                        return user;
                }
            }
            return null;
        }

        public void UpdateUser(int id, User updateUserDetails)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile, ReadOptions);
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
                string text = System.IO.File.ReadAllText(FilePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUserDetails));
                System.IO.File.WriteAllText(FilePath, text);
            }
        }
    }
}