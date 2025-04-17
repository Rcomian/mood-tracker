using Dapper;
using System.Data;
using MoodTracker.API.Models;
using MoodTracker.API.Data;

namespace MoodTracker.API.Repositories
{
    public class MoodRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public MoodRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<MoodEntry>> GetMoodsByUserId(int userId)
        {
            using var connection = _connectionFactory.CreateConnection();
            var moods = await connection.QueryAsync<MoodEntry>(
                "GetMoodsByUserId",
                new { UserId = userId },
                commandType: CommandType.StoredProcedure);

            return moods;
        }

        public async Task InsertMoodEntry(MoodEntry mood)
        {
            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(
                "InsertMoodEntry",
                new
                {
                    mood.UserId,
                    mood.Mood,
                    mood.Notes,
                    mood.Date
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
