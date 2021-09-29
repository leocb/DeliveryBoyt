using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBoyt.Core
{
    public static class LoggingService
    {
        public static Task LogAsync(LogMessage message)
        {
            if (message.Exception is CommandException cmdException)
            {
                Debug.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}"
                    + $" failed to execute in {cmdException.Context.Channel}.");
                Debug.WriteLine(cmdException);
            }
            else
                Debug.WriteLine($"[General/{message.Severity}] {message}");

            return Task.CompletedTask;
        }
    }
}
