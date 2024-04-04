using Disqord.Bot.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.Configuration;

namespace Teddy_Ingentive_Discord_Bot
{
    internal class DiscBotModule
    {
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<DiscBotModule>(); // Loads User Secrets at the main level

            IConfiguration configuration = builder.Build();

            string discordBotToken = configuration["DiscordBotToken"];

            // Host encapsulates our application
            using (var host = CreateHost(discordBotToken)) // Passes through our token NOTE: I would like to put some more time into thinking about where I would implement a fix for this when the Token is null as the bot would break.
            {
                host.Run();
            }
        }

        private static IHost CreateHost(string discordBotToken)
        {
            // Configuratrion for Host goes here
            return new HostBuilder()
                .UseSerilog((context, logger) =>
                {
                    // Instructions written to console log via serilog
                    logger.WriteTo.Console();
                }).ConfigureDiscordBot((context, bot) =>
                {
                    // Setting bot token
                    bot.Token = discordBotToken;

                    // Allows ?/! to be used as commands
                    bot.Prefixes = new[] { "?", "!" };
                })
                .Build();

        }
    }
}