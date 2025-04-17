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

        public async Task<PagedResult<MoodEntry>> GetPagedMoods(int userId, int page, int pageSize)
        {
            using var conn = _connectionFactory.CreateConnection();

            using var multi = await conn.QueryMultipleAsync(
                "GetMoodsByUserId",
                new { UserId = userId, Page = page, PageSize = pageSize },
                commandType: CommandType.StoredProcedure);

            var totalCount = await multi.ReadSingleAsync<int>();
            var moods = await multi.ReadAsync<MoodEntry>();

            return new PagedResult<MoodEntry>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Data = moods
            };
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
