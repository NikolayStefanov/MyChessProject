using MyChessProject.Common;
using MyChessProject.Common.Console;
using MyChessProject.InputProviders.Contracts;
using MyChessProject.Players;
using MyChessProject.Players.Contracts;
using System;
using System.Collections.Generic;

namespace MyChessProject.InputProviders
{
    public class ConsoleInputProvider : IInputProvider
    {
        private string playerNameText = "Enter player {0} name: ";

        public Move GetNextPlayerMove(IPlayer player)
        {
            // Command is in format : a5-c5
            ConsoleHelper.ClearRow(ConsoleConstants.ConsoleRowForPlayer);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, ConsoleConstants.ConsoleRowForPlayer);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"{(player.Name).ToUpper()} IS NEXT: ");
            var positionAsString = Console.ReadLine().Trim().ToLower();
            var move = ConsoleHelper.CreateMoveFromCommand(positionAsString);
            return move;


        }

        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelper.SetCursorAtCenter(playerNameText.Length);

                Console.Write(string.Format(playerNameText, i));
                string name = Console.ReadLine();
                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }
            return players;
        }
    }
}
