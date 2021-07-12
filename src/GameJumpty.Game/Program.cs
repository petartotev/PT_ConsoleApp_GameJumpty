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
            ConsoleManager.SetDefaultConsole(63, 33);

            while (true)
            {
                GameEngine.ShowMenu();
                GameEngine.GetMenuCommand();

                switch (GameEngine.CurrentCommand)
                {
                    case Command.Play:
                        CancellationTokenSource source = new CancellationTokenSource();
                        await GameEngine.PlayAsync(source).ConfigureAwait(true);
                        break;
                    case Command.Results:
                        await ResultsManager.ShowResultsAsync();
                        break;
                    case Command.Music:
                        MusicManager.IsMusicOn = !MusicManager.IsMusicOn;
                        break;
                    case Command.Exit:
                        Environment.Exit(0);
                        break;
                }

                Console.Clear();
            }
        }
    }
}
