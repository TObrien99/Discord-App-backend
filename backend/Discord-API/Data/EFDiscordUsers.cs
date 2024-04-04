using Microsoft.EntityFrameworkCore;

namespace Discord_API.Data
{
    public class EFDiscordUsers : IDiscordUsersRepository
    {
        private DiscordAppContext _appContext;

        // when the class is constructed it will instantiate a DiscordAppContext
        public EFDiscordUsers(DiscordAppContext temp)
        {
            _appContext = temp;
        }

        // grabs info from DiscordBotRequests and puts it into an enumerable
        public IEnumerable<DiscordUsers> GetUsers => _appContext.DiscordUsers;

        public async Task<DiscordUsers> CreateDiscordUsersAsync(DiscordUsers discordUsers)
        {
            _appContext.DiscordUsers.Add(discordUsers);
            await _appContext.SaveChangesAsync();
            return discordUsers;
        }

        public async Task<DiscordUsers> GetUserById(int userId)
        {
            return await _appContext.DiscordUsers.FindAsync(userId);
        }

        public async Task UpdateDiscordUsersAsync(DiscordUsers discordUser, bool isBanned, bool isAdmin)
        {
            var userToUpdate = await _appContext.DiscordUsers.FindAsync(discordUser.Id);
            if (userToUpdate != null)
            {
                userToUpdate.isBanned = isBanned;
                userToUpdate.isAdmin = isAdmin;
                await _appContext.SaveChangesAsync();
            }
        }
    }
}
