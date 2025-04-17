using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodTracker.API.Models
{
    public class MoodEntry
    {
        public int Id { get; set; }

        [Required]
        public string Mood { get; set; } = null!; // e.g., "happy", "sad"

        public string? Notes { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public int UserId { get; set; }
    }
}
