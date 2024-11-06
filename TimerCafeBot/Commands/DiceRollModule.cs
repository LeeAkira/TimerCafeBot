using Discord.Commands;

namespace TimerCafeBot.Commands;

public class DiceRollModule : ModuleBase<SocketCommandContext>
{
    [Command("roll")]
    [Summary("Rolls dices")]
    public async Task DiceRoll([Summary("Type 'roll XdY' where X is the number of dices and Y is the amount of faces")] string dices)
    {
        try
        {
            var sdices = dices.Split('d');
            int amount = int.Parse(sdices[0]);
            int faces = int.Parse(sdices[1]);
            var random = new Random();
            string result = "";

            for (int i = 0; i < amount; i += 1) {
                if (i > 0)
                    result += ", ";
                result += random.Next(faces) + 1;
            }

            await ReplyAsync(result.ToString());
        }
        catch(FormatException)
        {
            await ReplyAsync("Incorrect Format");
        }
    }
}
