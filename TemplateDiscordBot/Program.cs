using System;
using System.Threading.Tasks;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;
using TemplateDiscordBot.Models;

namespace TemplateDiscordBot
{
    public static class Program
    {
        internal static void Main()
            => MainAsync().ConfigureAwait(false).GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            var config = await Configuration.LoadFromFileAsync();

            // Log Serilog's own log messages to console (useful if it cannot connect to Seq)
            SelfLog.Enable(Console.WriteLine);

            // Write everything to console (including rate limit info, but only info+ to Seq)
            using var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Seq(config.SeqAddress, LogEventLevel.Information, apiKey: config.SeqToken)
                .Enrich.WithProperty("Environment", config.Environment)
                .Enrich.WithProperty("Application", "Discord Bot")
                .CreateLogger();

            var bot = new Bot(config, logger);
            await bot.StartAsync();

            await Task.Delay(-1);
        }
    }
}