using System.Data;
using System.Data.SqlClient;

namespace Extensions
{
    public static class DbExtensions
    {
        public static SqlDataReader GetReader(this IDbConnection dbConnection, string procedureName)
        {
            dbConnection.Open();

            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = (SqlConnection)dbConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = procedureName;

            return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}