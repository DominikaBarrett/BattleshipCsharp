using System;
using System.ComponentModel;

namespace BattleshipGame.Board
{
    public class Square
    {
        private (int i, int j) Position { get; set; }
        private SquareStatus squareStatus;

        public Square(int i, int j)
        {
            this.Position = (i, j);
            squareStatus = SquareStatus.EMPTY;
        }

        public char GetCharacter()
        {
            switch (squareStatus)
            {
                case SquareStatus.HIT:
                    return 'H';
                case SquareStatus.SHIP:
                    return 'S';
                case SquareStatus.EMPTY:
                    return '_';
                case SquareStatus.MISSED:
                    return 'M';
            }
            return '\0';
        }


        private enum SquareStatus
        {
            EMPTY,
            SHIP,
            HIT,
            MISSED
        }
    }
}