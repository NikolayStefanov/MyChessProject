using MyChessProject.Common;
using MyChessProject.Movements.Contracts;
using System.Collections.Generic;

namespace MyChessProject.Figures.Contracts
{
    public interface IFigure
    {
        ChessColor Color { get; }
        ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
