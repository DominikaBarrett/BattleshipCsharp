using static System.Console;
using System;
using System.ComponentModel.Design;

namespace BattleshipGame
{
    public class Battleship
    {
        private string Display;
        private string Input;
        private int HighScore;

        public void Start()
        {
            RunMainMenu();
            
        }

        private void RunMainMenu()
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Battleship is starting...");
            string prompt = @" 

▀█████████▄     ▄████████     ███         ███      ▄█          ▄████████    ▄████████    ▄█    █▄     ▄█     ▄███████▄ 
  ███    ███   ███    ███ ▀█████████▄ ▀█████████▄ ███         ███    ███   ███    ███   ███    ███   ███    ███    ███ 
  ███    ███   ███    ███    ▀███▀▀██    ▀███▀▀██ ███         ███    █▀    ███    █▀    ███    ███   ███▌   ███    ███ 
 ▄███▄▄▄██▀    ███    ███     ███   ▀     ███   ▀ ███        ▄███▄▄▄       ███         ▄███▄▄▄▄███▄▄ ███▌   ███    ███ 
▀▀███▀▀▀██▄  ▀███████████     ███         ███     ███       ▀▀███▀▀▀     ▀███████████ ▀▀███▀▀▀▀███▀  ███▌ ▀█████████▀  
  ███    ██▄   ███    ███     ███         ███     ███         ███    █▄           ███   ███    ███   ███    ███        
  ███    ███   ███    ███     ███         ███     ███▌    ▄   ███    ███    ▄█    ███   ███    ███   ███    ███        
▄█████████▀    ███    █▀     ▄████▀      ▄████▀   █████▄▄██   ██████████  ▄████████▀    ███    █▀    █▀    ▄████▀      
                                                  ▀                                                                    
   
                                                                           
";
            ResetColor();
            
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
                WriteLine("\nPress any key to exit...");
                ReadKey(true);
                Environment.Exit(0);
            }

            private void DisplayAboutInfo()
            {
                Clear();
                WriteLine(@"
Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, 
totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.
 Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui 
ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, 
consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.
");
                WriteLine("Press any key to return to main menu");
                ReadKey(true);
                RunMainMenu();

            }

            private void RunFirstChoice()
            
            {
                Console.WriteLine("Wybor tablicy?");
                
                ReadKey(true);
                ExitGame();
                

            }

        

    }
}



