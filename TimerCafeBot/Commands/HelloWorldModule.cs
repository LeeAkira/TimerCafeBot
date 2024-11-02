using Discord.Commands;

namespace TimerCafeBot.Commands;

public class HelloWorldModule : ModuleBase<SocketCommandContext>
{
    [Command("say")]
    [Summary("Echoes a message.")]
    public async Task SayAsync([Remainder][Summary("The text to echo")] string echo)
        => await ReplyAsync(echo);
}
