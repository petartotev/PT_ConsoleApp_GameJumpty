using GameJumpty.Game.Models;
using GameJumpty.Game.Models.Constants;
using GameJumpty.Game.Models.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameJumpty.Game.Core
{
    public static class GameEngine
    {
        private static readonly Random _random = new Random();

        public static Command CurrentCommand { get; set; }

        public static void ShowMenu()
        {
            ConsolePrinter.PrintLine(string.Format(ConsoleElements.Menu, MusicManager.IsMusicOn ? ConsoleElements.On : ConsoleElements.Off));
        }

        public static async Task PlayAsync(CancellationTokenSource sourceMain)
        {
            int jumpTimeCurrent = GameConstants.Character.JumpTimeCurrent;
            int jumpTimeMaximum = GameConstants.Character.JumpTimeMaximum;

            while (true)
            {
                // A cancellation token is needed for the song playing on a Worker Thread to be stopped from the current Main Thread once GAME OVER (WON / LOST) 
                CancellationTokenSource sourceMusic = new CancellationTokenSource();

                Character.Score = GameConstants.Game.ResultDefault;
                Character.Position = GameConstants.Character.DefaultCharacterPosition;

                if (MusicManager.IsMusicOn)
                {
                    var song = MusicManager.GetRandomSong();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    MusicManager.PlayMusicAsync(song, sourceMusic, sourceMain);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                }

                while (true)
                {
                    Character.CurrentDirection = Direction.Idle;

                    try
                    {
                        string[] form = GetRandomObstacle();

                        for (int w = Console.WindowWidth - form.Length - 1; w >= 0; w--)
                        {
                            if (Character.Score == GameConstants.Game.ResultWinning)
                            {
                                break;
                            }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                            Character.SetDirectionByInputAsync(sourceMain);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

                            if (sourceMain.Token.IsCancellationRequested)
                            {
                                return;
                            }

                            Character.MoveHorizontally();

                            if (Character.CurrentDirection == Direction.Up)
                            {
                                Character.IsAlreadyInAir = true;
                            }

                            if (Character.IsAlreadyInAir)
                            {
                                jumpTimeCurrent++;

                                if (jumpTimeCurrent == jumpTimeMaximum)
                                {
                                    jumpTimeCurrent = 0;
                                    Character.IsAlreadyInAir = false;

                                    if (Character.Position >= w || (Character.Position <= 7 && w >= 50))
                                    {
                                        Character.Score++;
                                    }
                                }
                            }

                            ConsolePrinter.PrintLine(w % 4 == 0 ? ConsoleElements.Sky1 : ConsoleElements.Sky2, ConsoleColor.DarkCyan);
                            ConsolePrinter.PrintLine(w % 4 == 0 ? ConsoleElements.Sky2 : ConsoleElements.Sky1, ConsoleColor.Cyan);

                            if (Character.IsAlreadyInAir)
                            {
                                for (int l = 0; l <= 4; l++)
                                {
                                    ConsolePrinter.PrintLine(new string(' ', Character.Position) + ConsoleElements.CharacterJump[l]);
                                }
                                for (int l = 1; l <= 3; l++)
                                {
                                    ConsolePrinter.PrintLine();
                                }
                                for (int l = 0; l <= 6; l++)
                                {
                                    ConsolePrinter.PrintLine(new string(' ', w) + form[l], ConsoleColor.Green);
                                }
                            }
                            else
                            {
                                for (int l = 1; l <= 8; l++)
                                {
                                    ConsolePrinter.PrintLine();
                                }
                                for (int l = 0; l <= 6; l++)
                                {
                                    ConsolePrinter.PrintLine(Character.Position <= w ?
                                    (new string(' ', Character.Position) + ConsoleElements.CharacterIdle[l] + new string(' ', w - 7 - Character.Position) + form[l]) :
                                    (new string(' ', w) + form[l] + new string(' ', Character.Position - w - 7) + ConsoleElements.CharacterIdle[l]));
                                }
                            }

                            ConsolePrinter.PrintLine(w % 2 == 0 ? ConsoleElements.Grass1 : ConsoleElements.Grass2, ConsoleColor.Yellow);

                            for (int l = 0; l < 13; l++)
                            {
                                ConsolePrinter.PrintLine(l != 6 ?
                                    ConsoleElements.Ground :
                                    string.Format(ConsoleElements.Result, Character.Score.ToString("D6")), ConsoleColor.DarkYellow);
                            }

                            Character.CurrentDirection = Direction.Idle;
                            Thread.Sleep(GameConstants.Game.Speed);
                            Console.Clear();
                        };
                    }
                    catch (Exception)
                    {
                        // LOST
                        Console.Clear();
                        ConsolePrinter.PrintLine(string.Format(ConsoleElements.Lost, Character.Score.ToString("D2")), ConsoleColor.Red);
                        await ResultsManager.ChangeResultsAsync(false);
                        break;
                    }

                    // WON
                    if (Character.Score == GameConstants.Game.ResultWinning)
                    {
                        Console.Clear();
                        ConsolePrinter.PrintLine(ConsoleElements.Won, ConsoleColor.Green);
                        await ResultsManager.ChangeResultsAsync(true);
                        break;
                    }
                }

                sourceMusic.Cancel();
                Thread.Sleep(3000);
            }
        }

        public static void GetMenuCommand()
        {
            CurrentCommand = Console.ReadKey(true).Key switch
            {
                ConsoleKey.Spacebar => Command.Play,
                ConsoleKey.R => Command.Results,
                ConsoleKey.M => Command.Music,
                ConsoleKey.Escape => Command.Exit,
                _ => Command.None
            };
        }

        private static string[] GetRandomObstacle()
        {
            return ConsoleElements.Obstacles[_random.Next(1, ConsoleElements.Obstacles.Length)];
        }
    }
}
