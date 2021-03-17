using System;
using System.Text;
using BattleshipGame.BoardFolder;
using static System.Console;

namespace BattleshipGame.GetShow
{
    public class Display
    {
        public string MainMenu()
        {
           
           
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
            return prompt;
        }
        

        public void Exit()
        {
            WriteLine("\nPress any key to exit...");
        }
        

        public void InfoAbout()
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
        }

        public void ShowBoard(Square[,] seeBoard)
        {

          
            StringBuilder sb = new StringBuilder();
            var line = string.Empty;
            var alfa = string.Empty;
            for (int i = 0; i <= seeBoard.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= seeBoard.GetUpperBound(1); j++)
                {
                    if (i == 0)
                    {
                        if (i == 0 && j == 0)
                        {
                            alfa += $"   {(Alfa)j} ";
                        }
                        else
                        {
                            alfa += $"{(Alfa)j} ";
                        }
                       
                        if (j == seeBoard.GetUpperBound(1))
                        {
                            alfa += '\n';
                        }
                    }
                    
                    if (j == 0)
                    {
                        var len = (i + 1).ToString().Length;
                        if (len == 1)
                        {
                            line += $"{i + 1}  {seeBoard[i, j].GetCharacter().ToString()} ";
                        }
                        else
                        {
                            line += $"{i + 1} {seeBoard[i, j].GetCharacter().ToString()} ";
                        }
                        
                        
                    }
                    else
                    {
                        line += $"{seeBoard[i, j].GetCharacter().ToString()} ";
                    }
                }

                sb.AppendLine(line);
                line = String.Empty;
            }

            sb.Insert(0, alfa);
            // Console.Clear();
            Write(sb);
        }

      

        public void Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Alert(string alert)
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine($"{alert}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        
        
        
        public void Hit(int turnCounter)
        {
            WriteLine(@"  
           _ ._  _ , _ ._
        (_ ' ( `  )_  .__)
      ( (  (    )   `)  ) _)
     (__ (_   (_ . _) _) ,__)
         `~~`\ ' . /`~~`
              ;   ;
              /   \
_____________/_ __ \_____________");
            
            // method lets the player to know ship was hit
            turnCounter += 1;
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine("Boom.... Aaaaaaaaaaaaaaaaaa.........You got me!!!! ");
            // display a Score?
            WriteLine($"Score: {turnCounter}"); 
        }
        
        
        public void Sunk(int turnCounter)
        {
            WriteLine(@"
           ___
          /`  _\
          |  / 0|--.
     -   / \_|0`/ /.`'._/)
 - ~ -^_| /-_~ ^- ~_` - -~ _
 -  ~  -| |   - ~ -  ~  -
         \ \, ~   -   ~
         \_|
              
");
            // method lets the player to know ship was sunk
            turnCounter += 1;
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("Congratulation you sunk the ship!!!! ");
            WriteLine("I hope you they can swim.....");
            // display a Score?
            WriteLine($"Score: {turnCounter}"); 
        }
        
        
        public void Win(int turnCounter, string currentPlayer)
        {
            WriteLine(@"
                                   .''.       
       .''.      .        *''*    :_\/_:     . 
      :_\/_:   _\(/_  .:.*_\/_*   : /\ :  .'.:.'.
  .''.: /\ :   ./)\   ':'* /\ * :  '..'.  -=:o:=-
 :_\/_:'.:::.    ' *''*    * '.\'/.' _\(/_'.':'.'
 : /\ : :::::     *_\/_*     -= o =-  /)\    '  *
  '..'  ':::'     * /\ *     .'/.\'.   '
      *            *..*         :
         *
        *       

");
            // method lets the player to know who won
            turnCounter += 1;
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"Congratulation {currentPlayer}, You won!\n");
            // display a Score?
            WriteLine($"You've won in: {turnCounter/2} moves!"); 
        }

        public void Lose(int turnCounter)
        {
            // method lets player to know they lost
            ForegroundColor = ConsoleColor.Red;
            WriteLine("You lost.... ");
            // display a Score?
            WriteLine($"Score: {turnCounter}"); 
        }

        public void AskToPlayAgain()
        {
            
            // method that ask teh player if they want to play again
            WriteLine("Would you like to play again? (yes/no)");
            string playResponse = ReadLine().Trim().ToLower();
            if (playResponse == "yes")
            {
                var game = new Game.Game();
                // how can I solve that problem ?
                game.Round(); 
            }
            else
            {
                WriteLine("Had enough? '\n'-Ok. See you later");
            }
        }
    }
}