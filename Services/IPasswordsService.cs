namespace Services
{
    public interface IPasswordsService
    {
        PasswordResult EvaluatePassword(string password);
    }
}