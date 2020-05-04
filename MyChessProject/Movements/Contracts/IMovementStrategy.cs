using System.Collections.Generic;

namespace MyChessProject.Movements.Contracts
{
    public interface IMovementStrategy
    {
        IList<IMovement> GetMovements(string figure);
    }
}
