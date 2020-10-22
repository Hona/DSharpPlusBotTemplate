using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using TemplateDiscordBot.Models;

namespace TemplateDiscordBot.Commands.General
{
    public class GeneralModule : TemplateModuleBase
    {
        public Configuration Config { get; set; }

        [Command("echo")]
        [Description("Replies with the same text sent in the command")]
        public async Task KeyBeggingResponseAsync(CommandContext context, [RemainingText] string input)
        {
            await ReplyNewEmbedAsync(context, input, DiscordColor.Cyan);
        }
    }
}