using System;
using System.Collections.Generic;

namespace BattleshipGame.Game
{
    public class ComputerEasy : Player

    {
        private List<(int, int)> UsedCoordinates = new List<(int, int)>();
        

        protected override (int, int) GetPlayerCoordinates()
        {
            Random random = new Random();
            while (true)
            {
                int x = random.Next(0, BoardSize);
                int y = random.Next(0, BoardSize);

                if (!UsedCoordinates.Contains((x, y)))
                {
                    UsedCoordinates.Add((x, y));
                    return (x, y);
                }
            }
        }
    }
}