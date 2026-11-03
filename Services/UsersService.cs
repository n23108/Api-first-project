using Entities;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class UsersService
    {
        UserRepository userRepository = new UserRepository();
        public User AddUser(User user)
        {
            return userRepository.AddUser(user);
        }

        public User GetUser(LoginUser logInUser)
        {
            
            return userRepository.GetUser(logInUser);
        }
        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void UpdateUser(int id, User updateUserDetails)
        {
            userRepository.UpdateUser(id, updateUserDetails);
        }
    }
}
    

