using Disqord.Bot.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teddy_Ingentive_Discord_Bot
{
    public class DiscordHttpService
    {
        private readonly HttpClient _httpClient;
        private HttpDataModule? _dataModule;

        public DiscordHttpService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7183/"); // if I had more time I would add this to a config, also have the config linked to the API
        }

        public async Task StoreCommandAsync(HttpDataModule command)
        {
            try
            {
                var jsonCommand = JsonConvert.SerializeObject(command);
                var content = new StringContent(jsonCommand, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/DiscordBotRequests", content);

                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error storing command: {ex.Message}");
                throw;
            }
        }

        public HttpDataModule ExtractDiscordMessageData(BotMessageReceivedEventArgs e, int? TimerLength)
        {
            _dataModule = new HttpDataModule
            {
                Id = 0,
                DiscordUsernameID = e.Message.Author.Mention,
                RequestDate = DateTime.Now,
            };

            if (TimerLength.HasValue)
            {
                _dataModule.TimerLength = TimerLength.Value;
            }

            return _dataModule;
        }
    }
}
