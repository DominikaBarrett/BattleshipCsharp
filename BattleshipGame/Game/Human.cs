using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.BoardFolder;
using BattleshipGame.GetShow;

namespace BattleshipGame.Game
{
    public class Human : Player
    {
        protected override (int, int) GetPlayerCoordinates()
        {
            var shotCoordinates = Input.GetCoordinates(BoardSize);
            return shotCoordinates;
        }
    }
}