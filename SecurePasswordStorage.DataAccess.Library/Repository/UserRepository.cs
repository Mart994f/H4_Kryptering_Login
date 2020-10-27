using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SecurePasswordStorage.DataAccess.Library
{
    public class UserRepository : IUserRepository
    {
        #region Private Fields

        private string _connectionstring;

        #endregion

        #region Constructors

        public UserRepository()
        {
            _connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=User;Integrated Security=True";
        }

        #endregion

        #region Public Methods

        public int Create(string username, string salt, string hashedPassword)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", username);
                parameters.Add("@Salt", salt);
                parameters.Add("@PasswordHash", hashedPassword);

                return connection.Execute("CreateUser", parameters, commandType: CommandType.StoredProcedure,
                                          commandTimeout: 10);
            }
        }

        public IEnumerable<dynamic> Get(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return connection.Query("GetUser", parameters, commandType: CommandType.StoredProcedure,
                                                   commandTimeout: 10);
            }
        }

        public List<dynamic> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                return connection.Query("GetAllUser", null, commandType: CommandType.StoredProcedure,
                                              commandTimeout: 10).ToList();
            }
        }

        public int Update(string username, string salt, string hashedPassword)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", username);
                parameters.Add("@Salt", salt);
                parameters.Add("@PasswordHash", hashedPassword);

                return connection.Execute("UpdateUser", parameters, commandType: CommandType.StoredProcedure,
                                          commandTimeout: 10);
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                return connection.Execute("DeleteUser", parameters, commandType: CommandType.StoredProcedure,
                                          commandTimeout: 10);
            }
        }

        public string GetSalt(string username)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", username);

                return connection.ExecuteScalar<string>("GetSalt", parameters, commandType: CommandType.StoredProcedure,
                                          commandTimeout: 10);
            }
        }

        public string GetPasswordHash(string username)
        {
            using (IDbConnection connection = new SqlConnection(_connectionstring))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", username);

                return connection.ExecuteScalar<string>("GetPasswordHash", parameters, commandType: CommandType.StoredProcedure,
                                          commandTimeout: 10);
            }
        }

        #endregion
    }
}
