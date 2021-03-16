﻿using System;
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


        public Player(string name, int boardSize)
        {
            NameOfPlayer = name;
            IsAlive = true;
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
            var shotCoordinates = inputInstance.GetCoordinates();
            var ships = this.ListOfShips;
            foreach (var ship in ships)
            {
                var shipFields = ship.fields;
                foreach (var field in shipFields)
                {
                    if (field.GetPosition() == shotCoordinates)
                    {
                        field.squareStatus = SquareStatus.HIT;
                        PlayerBoard[shotCoordinates.Item1, shotCoordinates.Item2] = field;
                        return;
                    }
                }
            }
            PlayerBoard[shotCoordinates.Item1, shotCoordinates.Item2].squareStatus = SquareStatus.MISSED;
        }
        
        
        public bool CheckIfIsAlive()
        {
            IsAlive = ListOfShips.Any(); // IsAlive is True if there is any in listOfShips, and false when it's empty
            return IsAlive;
        }
        
        
    }
}