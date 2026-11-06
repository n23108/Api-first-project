using Entities;

namespace Services
{
    public interface IUsersService
    {
        User AddUser(User user);
        User GetUser(UserLog logInUser);
        void UpdateUser(int id, User updateUserDetails);
    }
}