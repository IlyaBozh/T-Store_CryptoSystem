
using System.Data;
using System.Data.SqlClient;

namespace T_Store_CryptoSystem.DataLayer;

public class BaseRepository
{
    private readonly IDbConnection _connection;

    public BaseRepository(IDbConnection dbConnection)
    {
        _connection = dbConnection;
    }

    protected IDbConnection _dbConnection => new SqlConnection(_connection.ConnectionString);
}
