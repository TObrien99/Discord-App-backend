using Microsoft.EntityFrameworkCore;

namespace Discord_API.Data
{
    public class DiscordAppContext : DbContext
    {
        public DiscordAppContext(DbContextOptions<DiscordAppContext> options) : base(options) { }

        // discordUsers used for blocking users
        public DbSet<DiscordUsers> DiscordUsers { get; set; }

        // BotRequests used to track what requests are made and by who
        public DbSet<DiscordBotRequests> DiscordBotRequests { get; set;}

        // used for accessing the react login panel
        public DbSet<AdminPanelUsers> AdminPanelUsers { get; set; }
    }
}
