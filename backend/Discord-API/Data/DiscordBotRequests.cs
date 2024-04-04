using System.ComponentModel.DataAnnotations;

namespace Discord_API.Data
{
    public class DiscordBotRequests
    {
        [Key]
        public int Id { get; set; }
        public string? DiscordUsernameID { get; set; }
        public int TimerLength { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
