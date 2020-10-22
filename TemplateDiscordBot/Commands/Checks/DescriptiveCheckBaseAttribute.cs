using DSharpPlus.CommandsNext.Attributes;

namespace TemplateDiscordBot.Commands.Checks
{
    public abstract class DescriptiveCheckBaseAttribute : CheckBaseAttribute
    {
        public string FailureResponse { get; set; }
    }
}