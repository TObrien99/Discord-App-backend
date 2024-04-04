using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teddy_Ingentive_Discord_Bot
{
    public class HttpDataModule // will be the implementation of the API Interface see DiscordBotRequests.cs in the API app
    {
        public int Id { get; set; }
        public string? DiscordUsernameID { get; set; }
        public int TimerLength { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
