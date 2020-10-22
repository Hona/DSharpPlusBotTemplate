using System;
using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using TemplateDiscordBot.Models;
using TemplateDiscordBot.Utilities;

namespace TemplateDiscordBot.Services
{
    [Microservice(MicroserviceType.InjectAndInitialize)]
    public class CommandService
    {
        public CommandService(Configuration config, DiscordClient discordClient, IServiceProvider services)
        {
            var commands = discordClient.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new[]
                {
                    config.CommandPrefix
                },
                EnableDms = true,
                CaseSensitive = false,
                EnableMentionPrefix = true,
                Services = services
            });

            commands.RegisterCommands(Assembly.GetEntryAssembly());

            commands.CommandErrored += _commands_CommandErrored;
        }

        private async Task _commands_CommandErrored(CommandErrorEventArgs e)
        {
            if (e.Exception is ChecksFailedException exception)
            {
                var embed = new DiscordEmbedBuilder
                {
                    Title = "Access Denied",
                    Description = exception.FailedChecks.ToCleanResponse(),
                    Color = DiscordColor.Red
                };

                await e.Context.RespondAsync(embed: embed);
            }

            // No need to log when a command isn't found
            else if (!(e.Exception is CommandNotFoundException))
            {
                e.Context.Client.Logger.LogError(
                    $"{e.Context.User.Username} tried executing '{e.Command?.QualifiedName ?? "<unknown command>"}' but it errored: {e.Exception.GetType()}: {e.Exception.Message ?? "<no message>"}",
                    DateTime.Now);
            }
        }
    }
}