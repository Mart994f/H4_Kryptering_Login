namespace SecurePasswordStorage.BusinessLogic.Library.Controllers
{
    public interface IUserController
    {
        bool AuthenticateUser(string username, string password);
        bool RegisterUser(string username, string password);
    }
}