using Entities;
using Repositories;

namespace Services
{
    public class UsersService : IUsersService
    {
        IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public User GetUser(LoginUser loginUser)
        {
            return _userRepository.GetUser(loginUser);
        }

        public void UpdateUser(int id, User updateUserDetails)
        {
            _userRepository.UpdateUser(id, updateUserDetails);
        }
    }
}
