﻿using System.Collections.Generic;
using System.Linq;
using BattleshipGame.BoardFolder;
using BattleshipGame.GetShow;

namespace BattleshipGame.Game
{
    public class Player
    {
        private List<Ship> listOfShips = new List<Ship>();
        public bool IsAlive { get; private set; }
        public string nameOfPlayer { get; set; }
        

        public void SetPlayerName(string name)
        {
            nameOfPlayer = name;
        }


        public void setShipCollection()
        {
            Ship carrier = new Ship(5, nameOfPlayer);
            Ship battleship = new Ship(4, nameOfPlayer);
            Ship cruiser = new Ship(3, nameOfPlayer);
            Ship submarine = new Ship(2, nameOfPlayer);
            Ship destroyer = new Ship(1, nameOfPlayer);
            listOfShips.Add(carrier);
            listOfShips.Add(battleship);
            listOfShips.Add(cruiser);
            listOfShips.Add(submarine);
            listOfShips.Add(destroyer);
            // PLACE FOR CALLING FUNCTIONS FROM BoardFactory TO PLACE SQUARE OF SHIPS IN RANDOM OR MANUAL WAY
        }


        public void makeShot(Square[,] boardWithShips, Square[,] boardToShow)
        {
            var inputInstance = new Input();
            var shotCoordinates = inputInstance.GetCoordinates();
            // PLACE FOR CHECKING IF PROVIDED COORDINATES ARE SHIPS ON BOARD, OR NO
        }
        
        
        public bool CheckIfIsAlive()
        {
            IsAlive = listOfShips.Any(); // IsAlive is True if there is any in listOfShips, and false when it's empty
            return IsAlive;
        }
    }
}