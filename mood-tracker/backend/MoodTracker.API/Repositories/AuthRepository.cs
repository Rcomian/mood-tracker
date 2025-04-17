using Dapper;
using Microsoft.Data.SqlClient;
using MoodTracker.API.Data;
using MoodTracker.API.Models;

namespace MoodTracker.API.Repositories
{
    public class AuthRepository
    {
        private readonly SqlConnectionFactory _connFactory;

        public AuthRepository(SqlConnectionFactory connFactory)
        {
            _connFactory = connFactory;
        }

        public async Task<bool> UserExists(string username)
        {
            using var conn = _connFactory.CreateConnection();
            var result = await conn.QuerySingleOrDefaultAsync<int>(
                "SELECT 1 FROM Users WHERE Username = @Username",
                new { Username = username });

            return result == 1;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            using var conn = _connFactory.CreateConnection();
            return await conn.QuerySingleOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Username = @Username",
                new { Username = username });
        }

        public async Task CreateUser(string username, string passwordHash)
        {
            using var conn = _connFactory.CreateConnection();
            await conn.ExecuteAsync(
                "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash)",
                new { Username = username, PasswordHash = passwordHash });
        }
    }
}
