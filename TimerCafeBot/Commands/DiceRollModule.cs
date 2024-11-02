using Discord.Commands;

namespace TimerCafeBot.Commands;

public class DiceRollModule : ModuleBase<SocketCommandContext>
{
    [Command("roll")]
    public async Task DiceRoll()
    {
        var random = new Random();
        var result = random.Next(6)+1;
        await ReplyAsync(result.ToString());
    }
}
