using System;
using System.Collections.Generic;

namespace BattleshipGame.Game
{
    public class ComputerEasy : Player

    {
        private List<(int, int)> UsedCoordinates = new List<(int, int)>();


        protected override (int, int) GetPlayerCoordinates()
        {
            while (true)
            {
                int x = new Random().Next(0, BoardSize);
                int y = new Random().Next(0, BoardSize);

                if (!UsedCoordinates.Contains((x, y)))
                {
                    UsedCoordinates.Add((x, y));
                    return (x, y);
                }
            }
        }
    }
}