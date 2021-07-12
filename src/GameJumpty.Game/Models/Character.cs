using GameJumpty.Game.Models.Constants;
using GameJumpty.Game.Models.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameJumpty.Game.Models
{
    public static class Character
    {
        private const int FigureWidth = 7;
        private const int FigurePivot = FigureWidth / 2;

        private static int _pivot;
        private static int _score;

        static Character()
        {
            Position = FigurePivot;
            Score = GameConstants.Game.ResultDefault;
        }

        public static Direction CurrentDirection { get; set; }

        public static bool IsAlreadyInAir { get; set; }

        public static int Position
        {
            get
            {
                return _pivot;
            }
            set
            {
                if (value >= FigurePivot && value <= Console.WindowWidth - FigurePivot)
                {
                    _pivot = value;
                }
            }
        }

        public static int Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (value >= GameConstants.Game.ResultDefault && value <= GameConstants.Game.ResultWinning)
                {
                    _score = value;
                }
            }
        }

        public static void MoveHorizontally()
        {
            switch (CurrentDirection)
            {
                case Direction.Left:
                    Position--;
                    break;
                case Direction.Right:
                    Position++;
                    break;
                default:
                    break;
            }
        }

        public static async Task SetDirectionByInputAsync(CancellationTokenSource source)
        {
            await Task.Run(() =>
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                {
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
    }
}
