using MyChessProject.Board.Contracts;
using MyChessProject.Common;
using MyChessProject.Figures.Contracts;
using MyChessProject.Movements.Contracts;
using System;

namespace MyChessProject.Movements
{
    public class NormalKnightMovement : IMovement
    {
        private const string KnightInvalidMove = "{0}s cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);
            var color = figure.Color;
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if (figureAtPosition == null || color != figureAtPosition.Color)
            {
                if (rowDistance == 2 && colDistance == 1)
                {
                    return;
                }
                else if (colDistance == 2 && rowDistance == 1)
                {
                    return;
                }
            }

            throw new InvalidOperationException(KnightInvalidMove);
        }
    }
}
