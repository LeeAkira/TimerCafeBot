using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace TimerCafeBot;

public class Program
{
    public static IServiceProvider _serviceProvider;

    static IServiceProvider CreateProvider()
    {
        var config = new DiscordSocketConfig()
        {
            GatewayIntents = Discord.GatewayIntents.All
        };

        var collection = new ServiceCollection()
            .AddSingleton(config)
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<CommandService>()
            .AddSingleton<CommandHandler>();

        return collection.BuildServiceProvider();
    }

    public static async Task Main(string[] args)
    {
        _serviceProvider = CreateProvider();
        var client = _serviceProvider.GetRequiredService<DiscordSocketClient>();
        string token = "";
        var commandHandler = _serviceProvider.GetRequiredService<CommandHandler>();
        //client.MessageReceived
        client.Log += Log;

        await commandHandler.InstallCommandsAsync();

        await client.LoginAsync(Discord.TokenType.Bot, token);
        await client.StartAsync();

        await Task.Delay(-1);
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}
