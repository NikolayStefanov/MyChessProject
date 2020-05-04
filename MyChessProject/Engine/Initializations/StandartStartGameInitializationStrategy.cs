using MyChessProject.Board.Contracts;
using MyChessProject.Common;
using MyChessProject.Engine.Contracts;
using MyChessProject.Figures;
using MyChessProject.Figures.Contracts;
using MyChessProject.Players.Contracts;
using System;
using System.Collections.Generic;

namespace MyChessProject.Engine.Initializations
{
    public class StandartStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int StandartGameBoardTotalRowsAndCols = 8;

        private IList<Type> figureTypes;

        public StandartStartGameInitializationStrategy()
        {
            this.figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)
            };
        }
        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            this.ValidateStrategy(players, board);
            var firstPlayer = players[0];
            var secondPlayer = players[1];

            this.AddPownsToBoardRow(firstPlayer, board, 7);
            this.AddArmyToBoardRow(firstPlayer, board, 8);

            this.AddPownsToBoardRow(secondPlayer, board, 2);
            this.AddArmyToBoardRow(secondPlayer, board, 1);

        }
        private void AddArmyToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < StandartGameBoardTotalRowsAndCols; i++)
            {
                var figureType = this.figureTypes[i];
                var figureInstance = (IFigure)Activator.CreateInstance(figureType, player.Color);
                player.AddFigure(figureInstance);
                var position = new Position(chessRow, (char)('a' + i));
                board.AddFigure(figureInstance, position);
            }
        }
        private void AddPownsToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < StandartGameBoardTotalRowsAndCols; i++)
            {
                var pown = new Pawn(player.Color);
                player.AddFigure(pown);
                var position = new Position(chessRow, (char)('a' + i));
                board.AddFigure(pown, position);
            }
        }
        private void ValidateStrategy(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != GlobalConstants.StandartGameNumberOfPlayers)
            {
                throw new InvalidOperationException($"Standart Start Game Initialization Strategy must have exactly {GlobalConstants.StandartGameNumberOfPlayers} players!");
            }
            if (board.TotalRows != StandartGameBoardTotalRowsAndCols || board.TotalCols != StandartGameBoardTotalRowsAndCols)
            {
                throw new InvalidOperationException($"Standart Start Game Initialization Strategy must have exactly {StandartGameBoardTotalRowsAndCols} rows and cols!");

            }
        }
    }
}
