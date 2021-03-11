using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using static System.Console;

namespace BattleshipGame.Game
{
    public class Ship
    {
        enum ShipType { Carrier = 1, Battleship, Cruiser , Submarine , Destroyer};
        public string Name;
        public int Lenght;
        public bool Hit;
        public bool Sunk;
        // List<Square>;
        
        public Ship()
        {
            
            
        }
     
        public Ship(string name, int lenght)
        {
            this.Name = name;
            this.Lenght = lenght;
            
        }
        public Ship(string name, int lenght,bool hit)
        {
            this.Name = name;
            this.Lenght = lenght;
            this.Hit = hit;

        }

       

    
   

        // public static void SelectShip()
        // {
        //     List<Ship> shipList;
        //     shipList = new List<Ship>();
        //     shipList.Add(new Ship("Carrier", 5));
        //     shipList.Add(new Ship("Battleship", 4));
        //     shipList.Add(new Ship("Cruiser", 3));
        //     shipList.Add(new Ship("Submarine", 3));
        //     shipList.Add(new Ship("Destroyer", 2));
        // }


    }

   
}