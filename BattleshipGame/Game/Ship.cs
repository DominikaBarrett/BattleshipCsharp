﻿using System;
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
        private int type;
        private bool Hit;
        private bool Sunk;
        private List<Square> fields;
        
        public Ship(int typeOfShip)
        {
            this.type = typeOfShip;
            fields = new List<Square>(typeOfShip);
        }

        public void oneSquareForShip(int x, int y)
        {
            var oneField = new Square(x, y, true);
            fields.Add(oneField);
        }

    }

   
}