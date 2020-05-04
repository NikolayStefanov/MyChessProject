using MyChessProject.Common;
using MyChessProject.Figures.Contracts;
using MyChessProject.Movements.Contracts;
using System.Collections.Generic;

namespace MyChessProject.Figures
{
    public class King : BaseFigure, IFigure
    {
        public King(ChessColor color) : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
            return movementStrategy.GetMovements(this.GetType().Name);
        }
    }
}
