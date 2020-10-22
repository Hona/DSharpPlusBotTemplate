using TemplateDiscordBot.Commands.Checks;

namespace TemplateDiscordBot.Commands.Admin
{
    [RequireUserAdminRole]
    [RequireAdminBotChannel]
    public abstract class AdminModuleBase : TemplateModuleBase { }
}