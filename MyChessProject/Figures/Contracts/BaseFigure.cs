using MyChessProject.Common;
using MyChessProject.Movements.Contracts;
using System.Collections.Generic;

namespace MyChessProject.Figures.Contracts
{
     public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }
        public ChessColor Color { get; private set; }

        public abstract ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
