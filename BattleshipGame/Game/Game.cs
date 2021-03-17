using System;
using static System.Console;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using BattleshipGame.BoardFolder;
using BattleshipGame.GetShow;

namespace BattleshipGame.Game
{
    public class Game
    {
        private Display Display;
        private Input Input;
        private List<Player> ListOfPlayers = new List<Player>();
        private int BoardSize;

        public Game()
        {
            this.Display = new Display();
            this.Input = new Input();
        }

        public void Round()
        {
            BoardSize = Input.BoardSize();

            CreatePlayers(2);

            var turnCounter = 0;

            foreach (var player in ListOfPlayers)
            {
                ShipPlacement(player);
            }

            Player player1 = ListOfPlayers[0];
            Player player2 = ListOfPlayers[1];
            Player currentPLayer = player1;
            Player enemyPlayer = player2;
            
            //TODO intro
            Display.DisplayIntro();

            // loop for making shots until one of players is dead. Making moves is alternately - one move
            // for player1, one move for player 2
            while (player1.CheckIfIsAlive(player1.ListOfShips) & player2.CheckIfIsAlive(player2.ListOfShips))
            {
                // Clear();
                currentPLayer = turnCounter % 2 == 0 ? player1 : player2;
                enemyPlayer = turnCounter % 2 == 1 ? player1 : player2;
                // Display.Message($"{currentPLayer.NameOfPlayer} plays\n");
                Display.Message($"{player1.NameOfPlayer} board below");
                Display.ShowBoard(player1.PlayerBoard);
                Display.Message($"\n{player2.NameOfPlayer} board below");
                Display.ShowBoard(player2.PlayerBoard);
                WriteLine();
                Display.Message($"{currentPLayer.NameOfPlayer} turn!");
                enemyPlayer.MakeShot();
                turnCounter += 1;
                Clear();
            }
            Display.Win(turnCounter, currentPLayer.NameOfPlayer);
            Display.AskToPlayAgain();
            Display.DisplayOutro();
        }
        //TODO outro




        private void ShipPlacement(Player player)
        {
            BoardFactory factory = new BoardFactory(player);
            WriteLine();
            var prompt = $"{player.NameOfPlayer} choose method to place your ships:";
            string[] option = {"Random", "Manual"};

            GameMenu optionMenu = new GameMenu(prompt, option);
            int selectedIndex = optionMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    factory.RandomPlacement();
                    break;
                case 1:
                    factory.ManualPlacement();
                    break;
            }
        }

        private void CreatePlayers(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                WriteLine();
                // ReSharper disable once HeapView.BoxingAllocation
                Display.Message($"Please, provide name for player {i + 1}");
                var name = Input.GetNickname();
                Player player = new Player(name, BoardSize);
                ListOfPlayers.Add(player);
            }
            
        }
    }
}