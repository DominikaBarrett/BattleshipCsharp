namespace BattleshipGame.BoardFolder
{
    public class Square
    {
        private (int i, int j) Position { get; set; }
        public SquareStatus squareStatus;

        // public Square(int i, int j)
        // {
        //     this.Position = (i, j);
        //     squareStatus = SquareStatus.EMPTY;
        // }
        
        public Square(int i, int j, bool isShip = false)
        {
            this.Position = (i, j);
            if (isShip)
            {
                squareStatus = SquareStatus.SHIP;
            }
            else
            {
                squareStatus = SquareStatus.EMPTY;
            }
        }
        public Square(int i, int j, SquareStatus status)
        {
            this.Position = (i, j);
            squareStatus = status;
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
                case SquareStatus.TESTING:
                    return '#';
                case SquareStatus.SUNK:
                    return 'X';
            }
            return '\0';
        }


        public (int i, int j) GetPosition()
        {
            return this.Position;
        }
        
    }
}