using System;
using System.Text;
using static System.Console;

namespace BattleshipGame.GetShow
{
    public class Input
    {
        private Display Display;
        public Input()
        {
            this.Display = new Display();
        }

        public (int, int) GetCoordinates()
        {
            int x = -1;
            int y = -1;
            
            do
            {
                Display.Message("Enter coordinates (e.q. A1)");
                string userInput = ReadLine()?.ToUpper();
                if (userInput != null ^ userInput != "")
                {
                    char column = userInput[0];

                    if (column < 65 ^ column > 90)
                    {
                        Display.Alert("First position should be letter from A to Z!");
                    }
                    else
                    {
                        if (int.TryParse(userInput.Substring(1), out y))
                        {
                            x = column - 65;
                        }
                        else
                        {
                            Display.Alert("Second position should be number!");
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
                    Display.Alert("Your nickname length should be less than 25!");
                }
                else
                {
                    ready = true;
                }
            } while (ready != true);

            return nickname;
        }

        // public bool GetShipPosition()
        // {
        //     // return true - horizontal; false - vertical position
        //     while (true)
        //     {
        //        Display.Message("Enter position of the ship. (H)orizontal or (V)ertical:");
        //
        //         string userInput = ReadLine()?.ToUpper();
        //
        //         if (userInput == "H")
        //         {
        //             return true;
        //         }
        //
        //         if (userInput == "V")
        //         {
        //             return false;
        //         }
        //         Display.Alert("Enter only H for horizontal position or V for vertical position!");
        //         
        //     }
        // }

        public int BoardSize()
        {
            int size;
            while (true)
            {
                string userInput = ReadLine();
                if (int.TryParse(userInput, out size))
                {
                    if (size < 10 ^ size > 25)
                    {
                        Display.Alert("Size should be between 10 and 25!");
                    }
                    else
                    {
                        return size;
                    }
                }
                else
                {
                    Display.Alert("Enter only numbers!");
                }
            }
        }

        public ((int x, int y), ConsoleKey) GetShipPosition((int x, int y) shipCore)
        {
           
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.UpArrow)
            {
                --shipCore.x;
            }

            if (keyPressed == ConsoleKey.DownArrow)
            {
                ++shipCore.x;
            }

            if (keyPressed == ConsoleKey.LeftArrow)
            {
                --shipCore.y;
            }

            if (keyPressed == ConsoleKey.RightArrow)
            {
                ++shipCore.y;
            }

            return (shipCore, keyPressed);
        }
    }
}