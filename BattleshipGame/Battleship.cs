using static System.Console;
using System;
using BattleshipGame.GetShow;

namespace BattleshipGame
{
    public class Battleship
    {
        private Display Display;
        private string Input;
        private int HighScore;

        public Battleship()
        {
            Display display = new Display();
            this.Display = display;
        }

        public void Start()
        {   
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            var prompt = Display.MainMenu();
            string[] options = {"Play", "About", "Exit"};
            GameMenu mainGameMenu = new GameMenu(prompt, options);
            int selectedIndex = mainGameMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
            }

        }

        
            private void ExitGame()
            {
                Display.Exit();
                ReadKey(true);
                Environment.Exit(0);
            }

            private void DisplayAboutInfo()
            {
                Display.InfoAbout();
                ReadKey(true);
                RunMainMenu();

            }

            private void RunFirstChoice()
            
            {
                Display.RunProgram();
                ReadKey(true);
                ExitGame();
                

            }
        
    }
}



