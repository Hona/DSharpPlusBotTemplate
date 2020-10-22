using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;
using TemplateDiscordBot.Models;

namespace TemplateDiscordBot.Commands.Checks
{
    public class RequireAdminBotChannelAttribute : DescriptiveCheckBaseAttribute
    {
        public RequireAdminBotChannelAttribute() => FailureResponse = "Requires the bot admin channel";

        public override Task<bool> ExecuteCheckAsync(CommandContext context, bool help)
        {
            var config = context.Services.GetRequiredService<Configuration>();
            return Task.FromResult(context.Channel.Id == config.AdminBotChannelId);
        }
    }
}