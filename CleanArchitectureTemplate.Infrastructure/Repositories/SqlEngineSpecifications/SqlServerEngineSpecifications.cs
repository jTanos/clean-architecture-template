using System.Data;
using System.Data.SqlClient;
using CleanArchitectureTemplate.Core.Contracts.Repositories.SqlEngineSpecifications;

namespace CleanArchitectureTemplate.Infrastructure.Repositories.SqlEngineSpecifications
{
    public class SqlServerEngineSpecifications : ISqlServerEngineSpecifications
    {
        private readonly string _connectionString;
        private const string SqlServerLastIdentityValueInsertedQuery = "select CAST(SCOPE_IDENTITY() as bigint);";

        public SqlServerEngineSpecifications(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateAndOpenConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            return sqlConnection;
        }

        public string LastIdentityValueInsertedQuery()
        {
            return SqlServerLastIdentityValueInsertedQuery;
        }
    }
}
