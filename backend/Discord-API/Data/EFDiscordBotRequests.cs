using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Discord_API.Data
{
    public class EFDiscordBotRequests : IDiscordBotRequestsRepository
    {
        private  DiscordAppContext _appContext;

        // when the class is constructed it will instantiate a DiscordAppContext
        public EFDiscordBotRequests(DiscordAppContext temp) { 
            _appContext = temp;
        }

        // grabs info from DiscordBotRequests and puts it into an enumerable
        public IEnumerable<DiscordBotRequests> BotRequests => _appContext.DiscordBotRequests;

        public async Task<DiscordBotRequests> CreateBotRequestAsync(DiscordBotRequests botRequest)
        {
            _appContext.DiscordBotRequests.Add(botRequest);
            await _appContext.SaveChangesAsync();
            return botRequest;
        }
    }
}
