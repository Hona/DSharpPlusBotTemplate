using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TemplateDiscordBot.Constants;

namespace TemplateDiscordBot.Models
{
    public class Configuration
    {
        [JsonPropertyName("environment")] public string Environment { get; set; }

        [HiddenConfig]
        [JsonPropertyName("bot_token")]
        public string BotToken { get; set; }

        [JsonPropertyName("command_prefix")] public string CommandPrefix { get; set; }
        [JsonPropertyName("admin_id")] public ulong AdminRoleID { get; set; }
        [JsonPropertyName("moderator_id")] public ulong ModeratorRoleID { get; set; }

        [JsonPropertyName("admin_bot_channel")]
        public ulong AdminBotChannelId { get; set; }

        [HiddenConfig]
        [JsonPropertyName("seq_address")]
        public string SeqAddress { get; set; }

        [HiddenConfig]
        [JsonPropertyName("seq_token")]
        public string SeqToken { get; set; }

        public static async Task<Configuration> LoadFromFileAsync()
        {
            if (!File.Exists(PathConstants.ConfigFilePath))
            {
                throw new FileNotFoundException(
                    $"No config file exists, expected it at: '{PathConstants.ConfigFilePath}'");
            }

            // File exists, get the config
            await using var fileStream = File.OpenRead(PathConstants.ConfigFilePath);
            return await JsonSerializer.DeserializeAsync<Configuration>(fileStream);
        }

        public async Task SaveToFileAsync()
        {
            await using var fileStream = File.Open(PathConstants.ConfigFilePath, FileMode.Create);

            await JsonSerializer.SerializeAsync(fileStream, this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}