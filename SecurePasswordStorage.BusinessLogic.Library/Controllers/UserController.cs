using BusinessLogic.Library.Services;
using SecurePasswordStorage.DataAccess.Library;

namespace SecurePasswordStorage.BusinessLogic.Library.Controllers
{
    public class UserController : IUserController
    {
        #region Private Fields

        private IUserRepository _userRepository;

        private ISha256HashService _sha256HashService;

        #endregion

        #region Constructors

        public UserController()
        {
            _userRepository = new UserRepository();
            _sha256HashService = new Sha256HashService();
        }

        #endregion

        #region Public Methods

        public bool RegisterUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            string salt = _sha256HashService.GetSalt();
            string hashedPassword = _sha256HashService.ComputeHashWithSalt(password, salt);

            if (_userRepository.Create(username, salt, hashedPassword) > 0)
            {
                return true;
            }

            return false;
        }

        public bool AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            string salt = _userRepository.GetSalt(username);
            string computedHash = _sha256HashService.ComputeHashWithSalt(password, salt);
            string storedHash = _userRepository.GetPasswordHash(username);

            return _sha256HashService.ValidateHash(computedHash, storedHash);
        }

        #endregion

        #region Private Helper Methods



        #endregion
    }
}
