using System;
using System.Collections.Generic;
using BattleshipGame.Game;
using BattleshipGame.GetShow;
using static System.Console;

namespace BattleshipGame.BoardFolder
{
    public class BoardFactory
    {
        private Display Display = new Display();
        private Input Input = new Input();

        public void RandomPlacement()
        {
        }

        public void ManualPlacement(Player player)
        {
            var boardSize = player.PlayerBoard.GetUpperBound(0);
            var listOfShips = player.ListOfShips;
            var playerBoard = player.PlayerBoard;
            List<(int, int)> usedSquare = new List<(int, int)>();

            foreach (var ship in listOfShips)
            {
                (int x, int y) shipCore = (0, 0);
                bool isVertical = true;
                bool ready = false;
                bool isAllowed = false;
                ConsoleKey keyPressed;

                do
                {
                    var shipProposedPosition = GenerateShipPositions(shipCore, isVertical, ship.type);
                    var viewBoard = playerBoard.Clone() as Square[,];
                    
                    if (CheckBoundaries(shipProposedPosition, boardSize))
                        foreach (var square in shipProposedPosition)
                        {
                            viewBoard[square.x, square.y] = new Square(square.x, square.y, Square.SquareStatus.TESTING);
                        }

                    Clear();
                    Display.ShowBoard(viewBoard);

                    (shipCore, keyPressed) = Input.GetShipPosition(shipCore);

                    if (keyPressed == ConsoleKey.Spacebar)
                    {
                        isVertical = isVertical != true;
                    }

                    if (keyPressed == ConsoleKey.Enter)
                    {
                        isAllowed = TryToPlaceShip(shipCore, isVertical, ship.type, boardSize, usedSquare,
                            shipProposedPosition);
                        if (isAllowed)
                        {
                            foreach (var square in shipProposedPosition)
                            {
                                var testingSquare = ship.SquareForShip(square.x, square.y);
                                playerBoard[square.x, square.y] = testingSquare;
                                usedSquare.Add(square);
                            }

                            ready = true;
                        }
                        else
                        {
                            Display.Alert("Place not allowed!");
                        }
                    }
                } while (ready == false);
            }
        }

        private bool TryToPlaceShip((int x, int y) shipCore, bool isVertical, int shipLenght, int boardSize,
            List<(int, int)> usedSquare, List<(int, int)> shipProposedPosition)
        {
            if (CheckBoundaries(shipProposedPosition, boardSize) & CheckSpot(shipProposedPosition, usedSquare))
            {
                return true;
            }

            return false;
        }

        private List<(int x, int y)> GenerateShipPositions((int x, int y) shipCore, bool isVertical, int shipLenght)
        {
            List<(int x, int y)> shipSquares = new List<(int x, int y)>();
            for (int i = 0; i < shipLenght; i++)
            {
                if (isVertical)
                {
                    shipSquares.Add(shipCore);
                    ++shipCore.x;
                }
                else
                {
                    shipSquares.Add(shipCore);
                    ++shipCore.y;
                }
            }

            return shipSquares;
        }

        private bool CheckBoundaries(List<(int x, int y)> squares, int boardSize)
        {
            foreach (var square in squares)
            {
                if (square.x > boardSize ^ square.x < 0 ^ square.y > boardSize ^ square.y < 0)
                {
                    Display.Alert("Ship should be placed over a board!");
                    return false;
                }
            }

            return true;
        }

        private bool CheckSpot(List<(int x, int y)> squares, List<(int x, int y)> usedSquare)
        {
            foreach (var square in squares)
            {
                if (usedSquare.Contains(square))
                {
                    Display.Alert("You can't place ship on another ship!");
                    return false;
                }
            }

            return true;
        }
    }
}