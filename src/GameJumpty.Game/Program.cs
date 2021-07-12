using GameJumpty.Game.Core;
using GameJumpty.Game.Models.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameJumpty.Game
{
    public class Program
    {
        public Command CurrentCommand { get; set; }

        public static async Task Main()
        {
            ConsoleManager.SetDefaultConsole(width: 63, height: 33);

            while (true)
            {
                Console.Clear();
                GameEngine.ShowMenu();
                GameEngine.GetMenuCommand();

                switch (GameEngine.CurrentCommand)
                {
                    case Command.Play:
                        await GameEngine.PlayAsync(new CancellationTokenSource()).ConfigureAwait(true);
                        break;
                    case Command.Results:
                        await ResultsManager.ShowResultsAsync().ConfigureAwait(true);
                        break;
                    case Command.Music:
                        MusicManager.IsMusicOn = !MusicManager.IsMusicOn;
                        break;
                    case Command.Exit:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
