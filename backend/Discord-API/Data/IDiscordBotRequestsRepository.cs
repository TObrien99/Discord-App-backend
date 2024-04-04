namespace Discord_API.Data
{
    public interface IDiscordBotRequestsRepository
    {
        // implementing an interface using an Inumerable repository
        IEnumerable<DiscordBotRequests> BotRequests { get; }
        Task<DiscordBotRequests> CreateBotRequestAsync(DiscordBotRequests botRequest);
    }
}
