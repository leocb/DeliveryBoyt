using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DeliveryBoyt.Core
{
    public static class Bot
    {
        public static string Token { set; private get; }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private static DiscordSocketClient _client;
        public static async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, Token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

    }
}
