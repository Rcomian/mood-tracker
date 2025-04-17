using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoodTracker.API.Models;
using MoodTracker.API.Repositories;

namespace MoodTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MoodController : ControllerBase
    {
        private readonly MoodRepository _repo;

        public MoodController(MoodRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> GetMoods()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var moods = await _repo.GetMoodsByUserId(userId);
            return Ok(moods);
        }

        [HttpPost]
        public async Task<IActionResult> AddMood([FromBody] MoodEntry mood)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            mood.UserId = userId;
            await _repo.InsertMoodEntry(mood);
            return Ok();
        }
    }
}
