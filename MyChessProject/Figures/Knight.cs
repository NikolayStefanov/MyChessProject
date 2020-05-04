using MyChessProject.Common;
using MyChessProject.Figures.Contracts;
using MyChessProject.Movements.Contracts;
using System.Collections.Generic;

namespace MyChessProject.Figures
{
    public class Knight : BaseFigure, IFigure
    {
        public Knight(ChessColor color) : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
            return movementStrategy.GetMovements(this.GetType().Name);
        }
    }
}
