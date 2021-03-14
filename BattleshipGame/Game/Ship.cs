using System;
using System.Collections.Generic;
using BattleshipGame.BoardFolder;
using static System.Console;

namespace BattleshipGame.Game
{
    public class Ship
    {
        enum ShipType
        {
            Carrier = 5, 
            Battleship = 4, 
            Cruiser = 3,
            Submarine = 2,
            Destroyer = 1
        };

        private string Name;
        private string Owner;
        public int type;
        private bool Hit;
        private bool Sunk;
        private List<Square> fields;
        
        public Ship(int typeOfShip, string owner)
        {
            this.type = typeOfShip;
            fields = new List<Square>(typeOfShip);
            this.Owner = owner;
        }

        public Square SquareForShip(int x, int y)
        {
            var oneField = new Square(x, y, true);
            fields.Add(oneField);
            return oneField;
        }

    }

   
}