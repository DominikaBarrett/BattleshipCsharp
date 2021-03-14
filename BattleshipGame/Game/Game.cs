using System;
using System.Collections.Generic;
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
            Display.Message("Please, provide size of board between 10 - 25");
            BoardSize = Input.BoardSize();

            CreatePlayers(2);

            var turnCounter = 0;

            foreach (var player in ListOfPlayers)
            {
                shipPlacement(player);
            }

            Player player1 = ListOfPlayers[0];
            Player player2 = ListOfPlayers[1];
            Player currentPLayer;
            Player enemyPlayer;

            // loop for making shots until one of players is dead. Making moves is alternately - one move
            // for player1, one move for player 2
            while (player1.CheckIfIsAlive() & player2.CheckIfIsAlive())
            {
                currentPLayer = turnCounter % 2 == 0 ? player1 : player2;
                enemyPlayer = turnCounter % 2 == 1 ? player1 : player2;
                Display.ShowBoard(enemyPlayer.PlayerBoard);
                currentPLayer.MakeShot(currentPLayer.PlayerBoard, enemyPlayer.PlayerBoard);
                turnCounter += 1;
            }
        }


        private void shipPlacement(Player player)
        {
            BoardFactory factory = new BoardFactory(player);

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
                // ReSharper disable once HeapView.BoxingAllocation
                Display.Message($"Please, provide name for player {i + 1}");
                var name = Input.GetNickname();
                Player player = new Player(name, BoardSize);
                ListOfPlayers.Add(player);
            }
        }
    }
}