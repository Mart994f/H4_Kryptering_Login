using BusinessLogic.Library.Services;
using SecurePasswordStorage.DataAccess.Library;

namespace SecurePasswordStorage.BusinessLogic.Library.Controllers
{
    class UserController
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

        public void RegisterUser(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                string salt = _sha256HashService.GetSalt();
                string hashedPassword = _sha256HashService.ComputeHashWithSalt(password, salt);

                _userRepository.Create(username, salt, hashedPassword);
            }
        }

        public void AuthenticateUser(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                string salt = _userRepository.GetSalt(username);
                string hashedPassword = _sha256HashService.ComputeHashWithSalt(password, salt);
                string storedHash = 
                
            }
        }

        #endregion

        #region Private Helper Methods

        

        #endregion
    }
}
