using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUser(UserLog logInUser);
        void UpdateUser(int id, User updateUserDetails);
    }
}