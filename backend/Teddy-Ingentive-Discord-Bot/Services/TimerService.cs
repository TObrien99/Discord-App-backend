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
    public class HelloService : DiscordBotService
    {
        private readonly DiscordHttpService _discordHttpService = new DiscordHttpService();

        // Phrases the bot will only respond to
        private readonly string[] _phrases = { "TIMER" };

        // create local timer module independent of other services
        private readonly TimerModule _timerModule = new TimerModule(); 

        protected override async ValueTask OnNonCommandReceived(BotMessageReceivedEventArgs e)
        {
            // must be a discord id for the message to go through
            if (e.GuildId == null)
                return;

            // ignores system messages 
            if (e.Message is not IUserMessage)
                return;

            // ignores any message from a bot
            if (e.Message.Author.IsBot)
                return;

            // Ignores messages without any of the aboove defined phrases
            if (!_phrases.Any(phrase => e.Message.Content.Contains(phrase, StringComparison.OrdinalIgnoreCase)))
                return;




            // Trims the message to just the number given (removes 'Timer ' from "Timer 5" leaving just '5')
            string TimeStringInMinutes = e.Message.Content.Remove(0, 5).Trim();

            // Aknowledges the creation of the Timer to the user
            await Bot.SendMessageAsync(e.ChannelId, new LocalMessage()
                .WithContent($"Timer Started for: {TimeStringInMinutes} minutes {e.Message.Author.Mention}!"));

            // Converts from Str to float
            if (float.TryParse(TimeStringInMinutes, out float TimeFloatInMinutes))
            {
                // Conversions to allow 0.1 decimal values as minutes 
                float TimeFloatInSeconds = TimeFloatInMinutes * 60;
                int TimeIntInSeconds = (int)TimeFloatInSeconds;

                // Send request to API for Sql storing
                var messageData = _discordHttpService.ExtractDiscordMessageData(e, TimeIntInSeconds);
                await _discordHttpService.StoreCommandAsync(messageData);

                // Calls Timer function as if it's ?timer x (where x is a number in seconds)
                string TimerAlert = await _timerModule.Timer(TimeIntInSeconds);

                await Bot.SendMessageAsync(e.ChannelId, new LocalMessage()
                    .WithContent(TimerAlert));
            }
            else // if they have entered an incorrect number for the timer
            {
                await Bot.SendMessageAsync(e.ChannelId, new LocalMessage()
                .WithContent($"Invalid command format. Use: ?ping <duration> (Minutes){e.Message.Content} {e.Message.Author.Mention}!"));
            }

            
        }
    }
}
