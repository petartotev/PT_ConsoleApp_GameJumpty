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

        public static Direction? DirectionNow { get; set; }

        public static bool IsAlreadyInAir { get; set; }

        public static void ShowMenu()
        {
            ConsolePrinter.PrintLine(ConsoleElements.Menu);
        }

        public static void Play()
        {
            int jumpTimeCurr = GameConstants.JumpTimeCurrent;
            int jumpTimeMax = GameConstants.JumpTimeMaximum;

            Character character = new Character();

            while (true)
            {
                int result = 0;
                character.Position = 4;

                while (true)
                {
                    DirectionNow = Direction.Idle;

                    try
                    {
                        string[] form = GetRandomForm();

                        for (int w = Console.WindowWidth - form.Length - 1; w >= 0; w--)
                        {
                            if (result == GameConstants.ResultWinning)
                            {
                                break;
                            }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                            SetDirectionByInput();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

                            MoveHorizontally(character);

                            if (DirectionNow == null)
                            {
                                break;
                            }

                            if (DirectionNow == Direction.Up)
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
                                    result++;
                                }
                            }

                            ConsolePrinter.PrintLine(w % 4 == 0 ? ConsoleElements.Sky1 : ConsoleElements.Sky2, ConsoleColor.DarkCyan);
                            ConsolePrinter.PrintLine(w % 4 == 0 ? ConsoleElements.Sky2 : ConsoleElements.Sky1, ConsoleColor.Cyan);

                            if (IsAlreadyInAir)
                            {
                                ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterJump[0]);
                                ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterJump[1]);
                                ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterJump[2]);
                                ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterJump[3]);
                                ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterJump[4]);
                                ConsolePrinter.PrintLine();
                                ConsolePrinter.PrintLine();
                                ConsolePrinter.PrintLine();

                                ConsolePrinter.PrintLine(new string(' ', w) + form[0], ConsoleColor.Green);
                                ConsolePrinter.PrintLine(new string(' ', w) + form[1], ConsoleColor.Green);
                                ConsolePrinter.PrintLine(new string(' ', w) + form[2], ConsoleColor.Green);
                                ConsolePrinter.PrintLine(new string(' ', w) + form[3], ConsoleColor.Green);
                                ConsolePrinter.PrintLine(new string(' ', w) + form[4], ConsoleColor.Green);
                                ConsolePrinter.PrintLine(new string(' ', w) + form[5], ConsoleColor.Green);
                                ConsolePrinter.PrintLine(new string(' ', w) + form[6], ConsoleColor.Green);
                            }
                            else
                            {
                                ConsolePrinter.PrintLine();
                                ConsolePrinter.PrintLine();
                                ConsolePrinter.PrintLine();
                                ConsolePrinter.PrintLine();
                                ConsolePrinter.PrintLine();
                                ConsolePrinter.PrintLine();
                                ConsolePrinter.PrintLine();
                                ConsolePrinter.PrintLine();

                                if (character.Position <= w)
                                {
                                    ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterIdle[0] + new string(' ', w - 7 - character.Position) + form[0]);
                                    ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterIdle[1] + new string(' ', w - 7 - character.Position) + form[1]);
                                    ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterIdle[2] + new string(' ', w - 7 - character.Position) + form[2]);
                                    ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterIdle[3] + new string(' ', w - 7 - character.Position) + form[3]);
                                    ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterIdle[4] + new string(' ', w - 7 - character.Position) + form[4]);
                                    ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterIdle[5] + new string(' ', w - 7 - character.Position) + form[5]);
                                    ConsolePrinter.PrintLine(new string(' ', character.Position) + ConsoleElements.CharacterIdle[6] + new string(' ', w - 7 - character.Position) + form[6]);
                                }
                                else
                                {
                                    ConsolePrinter.PrintLine(new string(' ', w) + form[0] + new string(' ', character.Position - w - 7) + ConsoleElements.CharacterIdle[0]);
                                    ConsolePrinter.PrintLine(new string(' ', w) + form[1] + new string(' ', character.Position - w - 7) + ConsoleElements.CharacterIdle[1]);
                                    ConsolePrinter.PrintLine(new string(' ', w) + form[2] + new string(' ', character.Position - w - 7) + ConsoleElements.CharacterIdle[2]);
                                    ConsolePrinter.PrintLine(new string(' ', w) + form[3] + new string(' ', character.Position - w - 7) + ConsoleElements.CharacterIdle[3]);
                                    ConsolePrinter.PrintLine(new string(' ', w) + form[4] + new string(' ', character.Position - w - 7) + ConsoleElements.CharacterIdle[4]);
                                    ConsolePrinter.PrintLine(new string(' ', w) + form[5] + new string(' ', character.Position - w - 7) + ConsoleElements.CharacterIdle[5]);
                                    ConsolePrinter.PrintLine(new string(' ', w) + form[6] + new string(' ', character.Position - w - 7) + ConsoleElements.CharacterIdle[6]);
                                }
                            }

                            ConsolePrinter.PrintLine(w % 2 == 0 ? ConsoleElements.Grass1 : ConsoleElements.Grass2, ConsoleColor.Yellow);

                            for (int k = 0; k < 13; k++)
                            {
                                ConsolePrinter.PrintLine(k != 6 ? ConsoleElements.Ground : String.Format(ConsoleElements.Result, result.ToString("D6")), ConsoleColor.DarkYellow);
                            }

                            DirectionNow = Direction.Idle;
                            Thread.Sleep(50);
                            Console.Clear();
                        };

                        if (DirectionNow == null)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        ConsolePrinter.PrintLine(ConsoleElements.Lost, ConsoleColor.Red);
                        character.Position = 4;
                        result = 0;
                        Thread.Sleep(3000);
                    }

                    if (result == GameConstants.ResultWinning)
                    {
                        break;
                    }
                }

                if (DirectionNow == null)
                {
                    return;
                }

                ConsolePrinter.PrintLine(ConsoleElements.Won, ConsoleColor.Green);
                Thread.Sleep(3000);
            }
        }

        private static string[] GetRandomForm()
        {
            return _random.Next(1, 4) switch
            {
                1 => ConsoleElements.Block,
                2 => ConsoleElements.Cactus,
                3 => ConsoleElements.Snake,
                _ => ConsoleElements.Block
            };

        }

        public static void GetResults()
        {
        }

        public static async Task<string> GetMenuCommand()
        {
            return await Task.Run(() =>
            {
                return Console.ReadKey(true).Key switch
                {
                    ConsoleKey.Spacebar => "PLAY",
                    ConsoleKey.R => "RESULTS",
                    ConsoleKey.Escape => "EXIT",
                    _ => null
                };
            });
        }

        private static async Task SetDirectionByInput()
        {
            await Task.Run(() =>
            {
                DirectionNow = Console.ReadKey(true).Key switch
                {
                    ConsoleKey.Escape => null,
                    ConsoleKey.LeftArrow => Direction.Left,
                    ConsoleKey.RightArrow => Direction.Right,
                    ConsoleKey.UpArrow => IsAlreadyInAir ? Direction.Idle : Direction.Up,
                    ConsoleKey.DownArrow => Direction.Down,
                    _ => Direction.Idle
                };
            });
        }

        private static void MoveHorizontally(Character character)
        {
            switch (DirectionNow)
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
