using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disqord;
using Disqord.Bot.Hosting;
using Disqord.Rest;

namespace Teddy_Ingentive_Discord_Bot
{
    public class PingService : DiscordBotService
    {
        // respondable phrases
        private readonly string[] _phrases = { "PING" };

        protected override async ValueTask OnNonCommandReceived(BotMessageReceivedEventArgs e)
        {
            if (e.GuildId == null)
                return;

            // ignores system messages 
            if (e.Message is not IUserMessage)
                return;

            // ignores any message from a bot (prevents a loop of responding to it's own messages)
            if (e.Message.Author.IsBot)
                return;

            // Ignores messages without any of the aboove defined phrases
            if (!_phrases.Any(phrase => e.Message.Content.Contains(phrase, StringComparison.OrdinalIgnoreCase)))
                return;

            // Responds to the phrase by mentioning the author.
            await Bot.SendMessageAsync(e.ChannelId, new LocalMessage()
                .WithContent($"PONG {e.Message.Author.Mention}!"));
        }
    }
}
