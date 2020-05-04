using MyChessProject.Board.Contracts;
using MyChessProject.Common;
using MyChessProject.Figures.Contracts;
using MyChessProject.Movements.Contracts;
using System;

namespace MyChessProject.Movements
{
    public class NormalKingMovement : IMovement
    {
        private const string KingInvalidMove = "{0}s can move on positions next to him!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if ((rowDistance == 1 && colDistance == 0) || (rowDistance == 0 && colDistance == 1) || (rowDistance == 1 && colDistance == 1))
            {
                if (figureAtPosition == null || figureAtPosition.Color != figure.Color)
                {
                    return;
                }
            }

            throw new InvalidOperationException(KingInvalidMove);
        }
    }
}
