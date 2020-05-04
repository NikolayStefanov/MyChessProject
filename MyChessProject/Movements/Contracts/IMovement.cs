using MyChessProject.Board.Contracts;
using MyChessProject.Common;
using MyChessProject.Figures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyChessProject.Movements.Contracts
{
    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }

}
