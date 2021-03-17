using System;
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
        public Square[,] PlayerBoard;
        private int BoardSize;


        public Player(string name, int boardSize)
        {
            NameOfPlayer = name;
            IsAlive = true;
            BoardSize = boardSize;
            PlayerBoard = new BoardFolder.Board(boardSize).GetBoard();
            SetShipCollection();
        }
        

        private void SetShipCollection()
        {
            Ship carrier = new Ship(ShipType.Carrier, NameOfPlayer);
            Ship battleship = new Ship(ShipType.Battleship, NameOfPlayer);
            Ship cruiser = new Ship(ShipType.Cruiser, NameOfPlayer);
            Ship submarine = new Ship(ShipType.Submarine, NameOfPlayer);
            Ship destroyer = new Ship(ShipType.Destroyer, NameOfPlayer);
            ListOfShips.Add(carrier);
            ListOfShips.Add(battleship);
            ListOfShips.Add(cruiser);
            ListOfShips.Add(submarine);
            ListOfShips.Add(destroyer);
        }


        public void MakeShot()
        {
            var inputInstance = new Input();
            var shotCoordinates = inputInstance.GetCoordinates(BoardSize);
            var ships = this.ListOfShips;
            foreach (var ship in ships)
            {
                var shipFields = ship.fields;
                foreach (var field in shipFields)
                {
                    if (field.GetPosition() == shotCoordinates)
                    {
                        field.squareStatus = SquareStatus.HIT;
                        ship.TryToSunkShip();
                        PlayerBoard[shotCoordinates.Item1, shotCoordinates.Item2] = field;
                        return;
                    }
                }
            }
            PlayerBoard[shotCoordinates.Item1, shotCoordinates.Item2].squareStatus = SquareStatus.MISSED;
        }
        
        
        public bool CheckIfIsAlive(List<Ship> ships)
        {
            return !ships.TrueForAll(AllShipsSunk);
        }


        private bool AllShipsSunk(Ship ship)
        {
            foreach (var field in ship.fields)
                {
                    if (field.squareStatus != SquareStatus.SUNK)
                        return false;
                }
            return true;
        }
        
        
    }
}