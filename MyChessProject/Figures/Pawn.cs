using MyChessProject.Common;
using MyChessProject.Figures.Contracts;
using MyChessProject.Movements;
using MyChessProject.Movements.Contracts;
using System.Collections.Generic;

namespace MyChessProject.Figures
{
    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color) : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
            return movementStrategy.GetMovements(this.GetType().Name);
        }
    }
}
