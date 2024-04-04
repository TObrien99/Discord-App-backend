using Qmmands.Text;
using Qmmands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disqord;
using Disqord.Bot.Commands.Text;
using System.Threading.Tasks;

namespace Teddy_Ingentive_Discord_Bot
{
    public class TimerModule : DiscordTextModuleBase
    {
        [TextCommand("Timer")]
        public async Task<string> Timer(int time) // pass number after '?Timer' command as an argument
        {
           await Task.Delay(time * 1000);
           return "The " + time + " second timer is up!";
        }
    }
}
