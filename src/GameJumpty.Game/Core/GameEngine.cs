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

        public static Direction CurrentDirection { get; set; }

        public static bool IsAlreadyInAir { get; set; }

        public static void ShowMenu()
        {
            ConsolePrinter.PrintLine(string.Format(ConsoleElements.Menu, MusicManager.IsMusicOn ? ConsoleElements.On : ConsoleElements.Off));
        }

        public static async Task PlayAsync(CancellationTokenSource sourceMain)
        {
            int jumpTimeCurr = GameConstants.JumpTimeCurrent;
            int jumpTimeMax = GameConstants.JumpTimeMaximum;

            Character character = new Character();

            while (true)
            {
                int result = GameConstants.ResultDefault;
                character.Position = GameConstants.DefaultCharacterPosition;

                // The cancellation token is needed for the song that would be playing on a Worker Thread
                // to be stopped from the current Main Thread once the game is over (WON / LOST) 
                CancellationTokenSource sourceMusic = new CancellationTokenSource();

                var song = MusicManager.GetRandomSong();

                if (MusicManager.IsMusicOn)
                {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    MusicManager.PlayMusicAsync(song, sourceMusic, sourceMain);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                }

                while (true)
                {
                    if (!MusicManager.IsMusicOn)
                    {
                        sourceMusic.Cancel();
                    }

                    CurrentDirection = Direction.Idle;

                    try
                    {
                        string[] form = GetRandomObstacle();

                        for (int w = Console.WindowWidth - form.Length - 1; w >= 0; w--)
                        {
                            if (result == GameConstants.ResultWinning)
                            {
                                break;
                            }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                            SetDirectionByInputAsync(sourceMain);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

                            if (sourceMain.Token.IsCancellationRequested)
                            {
                                return;
                            }

                            MoveHorizontally(character);

                            if (CurrentCommand == Command.Quit)
                            {
                                break;
                            }

                            if (CurrentDirection == Direction.Up)
                            {
                                IsAlreadyInAir = true;
                            }

                            if (IsAlreadyInAir)
                            {
                                jumpTimeCurr++;

                                if (jumpTimeCurr == jumpTimeMax)
                                {
                                    jumpTimeCurr = 0;
                                    IsAlreadyInAir = false;

                                    if (character.Position >= w || (character.Position <= 7 && w >= 50))
                                    {
                                        result++;
                                    }
                                }
                            }

                            ConsolePrinter.PrintLine(w % 4 == 0 ? ConsoleElements.Sky1 : ConsoleElements.Sky2, ConsoleColor.DarkCyan);
                            ConsolePrinter.PrintLine(w % 4 == 0 ? ConsoleElements.Sky2 : ConsoleElements.Sky1, ConsoleColor.Cyan);

                            if (IsAlreadyInAir)
                            {
                                for (int i = 0; i <= 4; i++)
                                {
                                    ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterJump[i]);
                                }
                                for (int i = 1; i <= 3; i++)
                                {
                                    ConsolePrinter.PrintLine();
                                }
                                for (int i = 0; i <= 6; i++)
                                {
                                    ConsolePrinter.PrintLine(new string(' ', w) + form[i], ConsoleColor.Green);
                                }
                            }
                            else
                            {
                                for (int i = 1; i <= 8; i++)
                                {
                                    ConsolePrinter.PrintLine();
                                }
                                for (int i = 0; i <= 6; i++)
                                {
                                    ConsolePrinter.PrintLine(character.Position <= w ?
                                    (new string(' ', character.Position) + ConsoleElements.CharacterIdle[i] + new string(' ', w - 7 - character.Position) + form[i]) :
                                    (new string(' ', w) + form[i] + new string(' ', character.Position - w - 7) + ConsoleElements.CharacterIdle[i]));
                                }
                            }

                            ConsolePrinter.PrintLine(w % 2 == 0 ? ConsoleElements.Grass1 : ConsoleElements.Grass2, ConsoleColor.Yellow);

                            for (int k = 0; k < 13; k++)
                            {
                                ConsolePrinter.PrintLine(k != 6 ?
                                    ConsoleElements.Ground :
                                    string.Format(ConsoleElements.Result, result.ToString("D6")), ConsoleColor.DarkYellow);
                            }

                            CurrentDirection = Direction.Idle;
                            Thread.Sleep(50);
                            Console.Clear();
                        };

                        if (CurrentCommand == Command.Quit)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        // LOST
                        Console.Clear();
                        ConsolePrinter.PrintLine(string.Format(ConsoleElements.Lost, result.ToString("D2")), ConsoleColor.Red);
                        await ResultsManager.ChangeResultsAsync(false);
                        break;
                    }

                    // WON
                    if (result == GameConstants.ResultWinning)
                    {
                        Console.Clear();
                        ConsolePrinter.PrintLine(ConsoleElements.Won, ConsoleColor.Green);
                        await ResultsManager.ChangeResultsAsync(true);
                        break;
                    }
                }

                sourceMusic.Cancel();
                Thread.Sleep(3000);

                if (CurrentCommand == Command.Quit)
                {
                    return;
                }
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
            return _random.Next(1, 8) switch
            {
                1 => ConsoleElements.Block,
                2 => ConsoleElements.Cactus,
                3 => ConsoleElements.Snake,
                4 => ConsoleElements.Camel,
                5 => ConsoleElements.Gas,
                6 => ConsoleElements.Snail,
                7 => ConsoleElements.DarthVader,
                _ => ConsoleElements.Cactus
            };

        }

        private static async Task SetDirectionByInputAsync(CancellationTokenSource source)
        {
            await Task.Run(() =>
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                {
                    CurrentCommand = Command.Quit;
                    source.Cancel();
                }

                CurrentDirection = key switch
                {
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.A => Direction.Left,
                    ConsoleKey.RightArrow => Direction.Right,
                    ConsoleKey.D => Direction.Right,
                    ConsoleKey.UpArrow => IsAlreadyInAir ? Direction.Idle : Direction.Up,
                    ConsoleKey.W => IsAlreadyInAir ? Direction.Idle : Direction.Up,
                    _ => Direction.Idle
                };
            });
        }

        private static void MoveHorizontally(Character character)
        {
            switch (CurrentDirection)
            {
                case Direction.Left:
                    character.Position--;
                    break;
                case Direction.Right:
                    character.Position++;
                    break;
                default:
                    break;
            }
        }
    }
}
