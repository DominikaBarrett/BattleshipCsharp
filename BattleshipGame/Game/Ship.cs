using System;
using System.Collections.Generic;
using BattleshipGame.BoardFolder;
using static System.Console;

namespace BattleshipGame.Game
{
    public class Ship
    {
        public string Name;
        private string Owner;
        public ShipType type;
        private bool Hit;
        private bool Sunk;
        public List<Square> fields;
        
        public Ship(ShipType typeOfShip, string owner)
        {
            this.type = typeOfShip;
            fields = new List<Square>(GetShipLength());
            this.Owner = owner;
        }


        public int GetShipLength()
        {
            return (int) this.type;
        }
        

        public Square SquareForShip(int x, int y)
        {
            var oneField = new Square(x, y, true);
            fields.Add(oneField);
            return oneField;
        }
    }
}