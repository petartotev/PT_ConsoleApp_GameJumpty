using GameJumpty.Game.Models.Constants;
using System;

namespace GameJumpty.Game.Models
{
    public class Character
    {
        private const int FigureWidth = 7;
        private const int FigurePivot = FigureWidth / 2;

        private int _pivot;
        private int _score;

        public Character()
        {
            Position = FigurePivot;
            Score = GameConstants.ResultDefault;
        }

        public int Position
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

        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (value >= GameConstants.ResultDefault && value <= GameConstants.ResultWinning)
                {
                    _score = value;
                }
            }
        }
    }
}
