using System;
using System.Text;
using static System.Console;

namespace BattleshipGame.GetShow
{
    public class Input
    {
        // public ConsoleKeyInfo GetKeyPressed()
        // {
        //     return ReadKey(true);
        // }

        public (int, int) GetCoordinates()
        {
            int x = -1;
            int y = -1;
            
            do
            {
                WriteLine("Enter coordinates (e.q. A1)");
                string userInput = ReadLine()?.ToUpper();
                if (userInput != null)
                {
                    char column = userInput[0];

                    if (column < 65 ^ column > 90)
                    {
                        WriteLine("First position should be letter from A to Z!");
                    }
                    else
                    {
                        if (int.TryParse(userInput.Substring(1), out y))
                        {
                            x = column - 65;
                        }
                        else
                        {
                            WriteLine("Second position should be number!");
                        }
                    }
                }
            } while (x == -1 ^ y == -1);

            return (x, y);
        }

        public string GetNickname()
        {
            bool ready = false;
            string nickname;
                
            do
            {
                nickname = ReadLine();
                
                if (nickname != null && nickname.Length > 25)
                {
                    WriteLine("Your nickname length should less than 25!");
                }
                else
                {
                    ready = true;
                }
            } while (ready != true);

            return nickname;
        }

        public bool GetShipPosition()
        {
            // return true - horizontal; false - vertical position
            while (true)
            {
                WriteLine("Enter position of the ship. (H)orizontal or (V)ertical:");

                string userInput = ReadLine()?.ToUpper();

                if (userInput == "H")
                {
                    return true;
                }

                if (userInput == "V")
                {
                    return false;
                }
                WriteLine("Enter only H for horizontal position or V for vertical position!");
                
            }
        }

        public int BoardSize()
        {
            string userInput = ReadLine();
            var size = Int32.Parse(userInput ?? throw new InvalidOperationException());
            return size;
        }
    }
}