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

        public async Task<IActionResult> GetMoods([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            page = Math.Max(page, 1);
            pageSize = Math.Clamp(pageSize, 1, 100); // Enforce a safe max

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var result = await _repo.GetPagedMoods(userId, page, pageSize);
            return Ok(result);
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
