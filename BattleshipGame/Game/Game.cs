using System;
using System.Collections.Generic;
using System.Xml;
using BattleshipGame.Board;
using BattleshipGame.GetShow;

namespace BattleshipGame.Game
{
    public class Game
    {

        public void Round()
        {
            Display terminalMessages = new Display();  // make Display instance
            Input getInput = new Input();              // make Input instance
            
            terminalMessages.Message("Please, provide size of board between 10 - 25");
            var sizeOfBoard = getInput.BoardSize();
            var boardToSee = new BoardFolder.Board(sizeOfBoard).GetBoard();  // Get board to visualise in console
            var boardToPlacement = new BoardFolder.Board(sizeOfBoard).GetBoard(); // Get board to place ships
            terminalMessages.ShowBoard(boardToSee);
            
            Player player1 = new Player();
            Player player2 = new Player();
            List<Player> listOfPlayers = new List<Player>();
            listOfPlayers.Add(player1);
            listOfPlayers.Add(player2);

            Player currentPLayer;
            var turnCounter = 0;
            int playerCounter = 1;
            foreach (var player in listOfPlayers)       // setting names for players, providing ship collections
            {
                // ReSharper disable once HeapView.BoxingAllocation
                terminalMessages.Message($"Please, provide name for player {playerCounter}");
                var name = getInput.GetNickname();
                player.SetPlayerName(name);
                player.setShipCollection();
                playerCounter++;
            }

            foreach (var player in listOfPlayers)
            {
                shipPlacement(player);
            }

            // loop for making shots until one of players is dead. Making moves is alternately - one move
            // for player1, one move for player 2
            while (player1.CheckIfIsAlive() & player2.CheckIfIsAlive())
            {
                currentPLayer = turnCounter % 2 == 0 ? player1 : player2;
                currentPLayer.makeShot(boardToPlacement, boardToSee);
                turnCounter += 1;
            }

        }

        private void shipPlacement(Player player)
        {
            BoardFactory factory = new BoardFactory();
            var prompt = $"{player.nameOfPlayer} choose method to place your ships:";
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
        
    }
}