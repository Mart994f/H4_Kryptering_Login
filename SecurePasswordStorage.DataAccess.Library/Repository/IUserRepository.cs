namespace SecurePasswordStorage.DataAccess.Library
{
    public interface IUserRepository
    {
        int Create(string username, string salt, string hashedPassword);
        int Delete(int id);
        System.Collections.Generic.IEnumerable<dynamic> Get(int id);
        System.Collections.Generic.List<dynamic> GetAll();
        string GetSalt(string username);
        int Update(string username, string salt, string hashedPassword);
        string GetPasswordHash(string username);
    }
}