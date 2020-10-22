using TemplateDiscordBot.Commands.Checks;

namespace TemplateDiscordBot.Commands.Moderator
{
    [RequireUserModeratorRole]
    [RequireAdminBotChannel]
    public class ModeratorModuleBase : TemplateModuleBase { }
}