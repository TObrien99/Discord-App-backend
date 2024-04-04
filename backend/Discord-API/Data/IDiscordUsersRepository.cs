using Microsoft.AspNetCore.SignalR;

namespace Discord_API.Data
{
    public interface IDiscordUsersRepository
    {
        IEnumerable<DiscordUsers> GetUsers { get; }

        Task<DiscordUsers> CreateDiscordUsersAsync (DiscordUsers user);

        Task UpdateDiscordUsersAsync (DiscordUsers users, bool isBanned, bool isAdmin);
        Task<DiscordUsers> GetUserById(int userId);
    }
}
