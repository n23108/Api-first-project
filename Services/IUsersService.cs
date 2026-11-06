using Entities;

namespace Services
{
    public interface IUsersService
    {
        User AddUser(User user);
        User GetUser(LoginUser loginUser);
        void UpdateUser(int id, User updateUserDetails);
    }
}