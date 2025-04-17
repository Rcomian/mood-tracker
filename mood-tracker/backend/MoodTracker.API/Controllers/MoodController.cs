using Microsoft.AspNetCore.Mvc;
using MoodTracker.API.Models;
using MoodTracker.API.Repositories;

namespace MoodTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoodController : ControllerBase
    {
        private readonly MoodRepository _repo;

        public MoodController(MoodRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMoods(int userId)
        {
            Console.WriteLine($"Getting moods for user {userId}");
            var moods = await _repo.GetMoodsByUserId(userId);
            return Ok(moods);
        }

        [HttpPost]
        public async Task<IActionResult> AddMood([FromBody] MoodEntry mood)
        {
            await _repo.InsertMoodEntry(mood);
            return Ok();
        }
    }
}
