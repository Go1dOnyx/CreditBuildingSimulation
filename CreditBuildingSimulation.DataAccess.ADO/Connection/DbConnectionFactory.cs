using Microsoft.Data.SqlClient;

namespace CreditBuildingSimulation.DataAccess.ADO.Connection
{
    public interface IDbConnectionFactory
    {
       SqlConnection CreateConnection();
    }
    public class DbConnectionFactory: IDbConnectionFactory
    {
        private readonly string _connectionString;
        public DbConnectionFactory(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection() 
        {
            return new SqlConnection(_connectionString);
        }
    }
}
