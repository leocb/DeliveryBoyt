using Discord;
using Discord.WebSocket;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DeliveryBoyt.Core
{
    public static class Bot
    {
        public static string Token { set; private get; }
        private static DiscordSocketClient _client;


        public static async Task InitBot()
        {
            var _config = new DiscordSocketConfig { MessageCacheSize = 100 };
            _client = new DiscordSocketClient(_config);
            _client.Log += LoggingService.LogAsync;

            await _client.LoginAsync(TokenType.Bot, Token);
            await _client.StartAsync();


            _client.MessageReceived += MessageReceived;
            _client.MessageUpdated += MessageUpdated;
            _client.Ready += () =>
            {
                return Task.CompletedTask;
            };

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private static Task MessageReceived(SocketMessage message)
        {
            var a = message.Channel as SocketGuildChannel;
            _ = LoggingService.LogAsync(new LogMessage(LogSeverity.Verbose, "Received", $"[{a.Guild.Name} {message.Channel.Name}] {message}"));
            return Task.CompletedTask;
            
        }

        private static async Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
        {
            // If the message was not in the cache, downloading it will result in getting a copy of `after`.
            var message = await before.GetOrDownloadAsync();
            _ = LoggingService.LogAsync(new LogMessage(LogSeverity.Verbose, "Edited", $"{message} -> {after}"));
        }

    }
}
