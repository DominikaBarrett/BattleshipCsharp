using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.BoardFolder;

namespace BattleshipGame.Game
{
    public class ComputerNormal : ComputerEasy
    {
        private List<(int, int)> HighOrderCoordinates;
        

        protected override (int, int) GetPlayerCoordinates()
        {
            HighOrderCoordinates = new List<(int, int)>();
            AnalyzeBoard();
            if (HighOrderCoordinates.Any())
            {
                UsedCoordinates.Add(HighOrderCoordinates[0]);
                return HighOrderCoordinates[0];
            }

            return GetRandomCoordinates();

        }
        private void AnalyzeBoard()
        {
            foreach (var cell in PlayerBoard)
            {
                if (cell.squareStatus == SquareStatus.HIT)
                {
                    var generatedCells = GenerateCells(cell.GetPosition());
                    foreach (var candidateCell in generatedCells)
                    {
                        if (!UsedCoordinates.Contains(candidateCell))
                        {
                            HighOrderCoordinates.Add(candidateCell);
                        }
                    }
                }
            }   
        }

        private List<(int, int)> GenerateCells((int x,int y) core)
        {
            List<(int, int)> newCells = new List<(int, int)>();
            
            if (core.x + 1 <= BoardSize - 1)
            {
                newCells.Add((core.x + 1, core.y));
            }
            if (core.x - 1  >= 0)
            {
                newCells.Add((core.x - 1, core.y));
            }
            if (core.y + 1 <= BoardSize - 1)
            {
                newCells.Add((core.x, core.y + 1));
            }
            if (core.y -  1 >= 0)
            {
                newCells.Add((core.x, core.y - 1));
            }

            return newCells;
        }
        
    }
}