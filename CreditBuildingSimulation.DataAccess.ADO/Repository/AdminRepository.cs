using CreditBuildingSimulation.DataAccess.ADO.Connection;
using CreditBuildingSimulation.DataAccess.ADO.Repository.Contract;
using CreditBuildingSimulation.Models;
using Microsoft.Data.SqlClient;

namespace CreditBuildingSimulation.DataAccess.ADO.Repository
{
    public class AdminRepository: IAdminRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public AdminRepository(IDbConnectionFactory connectionFactory) 
        {
            _connectionFactory = connectionFactory;   
        }   
        public async Task<Admins> CreateAsync(Admins admin)  //missing return statement
        {
            using(var connection = _connectionFactory.CreateConnection()) 
            {
                await connection.OpenAsync();
                var query = "INSERT INTO Admins (Email, Password_Hash, FirstName, MiddleName, LastName, Admin_Role, Creation_Date)" +
                    " VALUES (@email, @password_hash, @first, @middle, @last, @role, @creation)"; //Add parameterized queries to prevent sql injections

                using (var command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@email", admin.Email);
                    command.Parameters.AddWithValue("@password_hash", admin.Password_Hash);
                    command.Parameters.AddWithValue("@first", admin.FirstName);
                    command.Parameters.AddWithValue("@middle", admin.MiddleName);
                    command.Parameters.AddWithValue("@last", admin.LastName);
                    command.Parameters.AddWithValue("@role", admin.Admin_Role);
                    command.Parameters.AddWithValue("@creation", admin.Creation_Date);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<Admins> UpdateAsync(Admins admin) 
        {
            using (var connection = _connectionFactory.CreateConnection()) 
            {
                await connection.OpenAsync();
                var query = "";
            }
        }
        public async Task<bool> DeleteAsync(Admins admin) //finish and return statement
        {
            using (var connection = _connectionFactory.CreateConnection()) 
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Admins WHERE AdminID = @id";

                using (var command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@id", admin.AdminID);

                    using (var reader = await command.ExecuteReaderAsync()) 
                    {
                        
                    }
                }
            }
        }
        public async Task<Admins?> GetByIdAsync(Guid adminID) 
        {
            using (var connection = _connectionFactory.CreateConnection()) 
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Admins WHERE AdminID = @id";

                using (var command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@id", adminID);

                    using (var reader = await command.ExecuteReaderAsync()) 
                    {
                        if (await reader.ReadAsync()) 
                        {
                            return new Admins
                            {
                                AdminID = reader.GetGuid(reader.GetOrdinal("AdminID")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Password_Hash = reader.GetString(reader.GetOrdinal("Password_Hash")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                MiddleName = reader.IsDBNull(reader.GetOrdinal("MiddleName"))
                                                ? null
                                                : reader.GetString(reader.GetOrdinal("MiddleName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Admin_Role = reader.GetString(reader.GetOrdinal("")) //missing
                            };
                        }

                        return null;
                    }
                }

            }   
        }
        public async Task<Admins?> GetByEmailAsync(string email) 
        {
            using (var connection = _connectionFactory.CreateConnection()) 
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Admins WHERE Email = @email";

                using (var command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@email", email);

                    using ( var reader = await command.ExecuteReaderAsync()) 
                    {
                        if (await reader.ReadAsync()) 
                        {
                            return new Admins
                            {
                                AdminID = reader.GetGuid(reader.GetOrdinal("AdminID")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Password_Hash = reader.GetString(reader.GetOrdinal("Password_Hash")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                MiddleName = reader.IsDBNull(reader.GetOrdinal("MiddleName"))
                                                ? null
                                                : reader.GetString(reader.GetOrdinal("MiddleName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Admin_Role = reader.GetString(reader.GetOrdinal("")) //missing
                            };
                        }

                        return null;
                    }
                }
            }
        }
        public async Task<List<Admins>> GetAllAsync() 
        {
            using (var connection =  _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Admins";

                using (var command = new SqlCommand(query, connection)) 
                {
                    using (var reader = await command.ExecuteReaderAsync()) 
                    {
                        var admins = new List<Admins>();

                        while (await reader.ReadAsync()) 
                        {
                            admins.Add(new Admins
                            {
                                AdminID = reader.GetGuid(0),
                                Email = reader.GetString(1),
                                Password_Hash = reader.GetString(2),
                                FirstName = reader.GetString(3),
                                MiddleName = reader.GetString(4),
                                LastName = reader.GetString(5),
                                Admin_Role = reader.GetString(6),
                                Creation_Date = reader.GetDateTime(7),
                            });
                        }

                        return admins;
                    }
                }
            }
        }
    }
}