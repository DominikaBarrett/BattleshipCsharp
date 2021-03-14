using System.Collections.Generic;
using System.Linq;
using BattleshipGame.BoardFolder;
using BattleshipGame.GetShow;

namespace BattleshipGame.Game
{
    public class Player
    {
        public List<Ship> ListOfShips = new List<Ship>();
        private bool IsAlive { get; set; }
        public readonly string NameOfPlayer;
        public Square[,]  PlayerBoard;
        

        public Player(string name, int boardSize)
        {
            NameOfPlayer = name;
            IsAlive = true;
            PlayerBoard = new BoardFolder.Board(boardSize).GetBoard();
            SetShipCollection();
        }
        

        private void SetShipCollection()
        {
            Ship carrier = new Ship(5, NameOfPlayer);
            Ship battleship = new Ship(4, NameOfPlayer);
            Ship cruiser = new Ship(3, NameOfPlayer);
            Ship submarine = new Ship(2, NameOfPlayer);
            Ship destroyer = new Ship(1, NameOfPlayer);
            ListOfShips.Add(carrier);
            ListOfShips.Add(battleship);
            ListOfShips.Add(cruiser);
            ListOfShips.Add(submarine);
            ListOfShips.Add(destroyer);
            // PLACE FOR CALLING FUNCTIONS FROM BoardFactory TO PLACE SQUARE OF SHIPS IN RANDOM OR MANUAL WAY
        }


        public void MakeShot(Square[,] boardWithShips, Square[,] boardToShow)
        {
            var inputInstance = new Input();
            var shotCoordinates = inputInstance.GetCoordinates();
            // PLACE FOR CHECKING IF PROVIDED COORDINATES ARE SHIPS ON BOARD, OR NO
        }
        
        
        public bool CheckIfIsAlive()
        {
            IsAlive = ListOfShips.Any(); // IsAlive is True if there is any in listOfShips, and false when it's empty
            return IsAlive;
        }
        
        
    }
}