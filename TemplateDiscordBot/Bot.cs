﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;
using TemplateDiscordBot.Models;
using TemplateDiscordBot.Utilities;
using ILogger = Serilog.ILogger;

namespace TemplateDiscordBot
{
    public class Bot
    {
        private readonly Configuration _config;
        private readonly DiscordClient _discordClient;
        private readonly ILogger _logger;

        public Bot(Configuration config, ILogger logger)
        {
            _config = config;
            _logger = logger;

            _discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = _config.BotToken,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.None,
                LoggerFactory = new SerilogLoggerFactory(logger),
                MessageCacheSize = 512
            });

            var services = BuildServiceProvider();
            services.InitializeMicroservices(Assembly.GetEntryAssembly());
        }

        private IServiceProvider BuildServiceProvider()
            => new ServiceCollection()
                .AddSingleton(_config)
                .AddSingleton(_logger)
                .AddSingleton(_discordClient)
                .InjectMicroservices(Assembly.GetEntryAssembly())
                .BuildServiceProvider();

        public async Task StartAsync()
            => await _discordClient.ConnectAsync();
    }
}