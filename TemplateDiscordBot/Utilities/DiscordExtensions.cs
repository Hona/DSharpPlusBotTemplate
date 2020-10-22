using DSharpPlus;

namespace TemplateDiscordBot.Utilities
{
    public static class DiscordExtensions
    {
        private const Permissions DangerousGuildPermissions = Permissions.Administrator | Permissions.BanMembers |
                                                              Permissions.DeafenMembers | Permissions.KickMembers |
                                                              Permissions.ManageChannels | Permissions.ManageEmojis |
                                                              Permissions.ManageGuild | Permissions.ManageMessages |
                                                              Permissions.ManageNicknames | Permissions.ManageRoles |
                                                              Permissions.ManageWebhooks | Permissions.MoveMembers |
                                                              Permissions.MuteMembers | Permissions.ViewAuditLog |
                                                              Permissions.UseExternalEmojis;

        public static Permissions GetDangerousPermissions(this Permissions guildPermissions)
            => DangerousGuildPermissions & guildPermissions;
    }
}