using GameJumpty.Game.Core;
using System;
using System.Threading.Tasks;

namespace GameJumpty.Game
{
    public class Program
    {
        public static async Task Main()
        {
            ConsoleManager.SetDefaultConsole(63, 33);

            while (true)
            {
                GameEngine.ShowMenu();

                switch (await GameEngine.GetMenuCommand())
                {
                    case "PLAY":
                        GameEngine.Play();
                        break;
                    case "RESULTS":
                        GameEngine.GetResults();
                        break;
                    case "EXIT":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
