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
    }
}