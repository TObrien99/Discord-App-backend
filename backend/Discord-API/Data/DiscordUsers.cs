using System.ComponentModel.DataAnnotations;

namespace Discord_API.Data
{
    public class DiscordUsers
    {
        [Key]
        public int Id { get; set; }
        public string? DiscordUsernameID { get; set; }
        public bool isBanned { get; set; }
        public bool isAdmin { get; set; }
    }
}
