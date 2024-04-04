using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disqord;
using Disqord.Bot.Commands.Text;
using Disqord.Bot;
using Qmmands;
using Qmmands.Text;
using Disqord.Extensions.Interactivity.Menus;

namespace Teddy_Ingentive_Discord_Bot
{
    public class BotModule : DiscordTextModuleBase
    {
        [TextCommand("Ping")]
        public async Task<IResult> Ping()
        {
            await Task.Delay(5000);
            return Response("Pong! ");
        }
    }
}
