using MyChessProject.Board.Contracts;
using MyChessProject.Players.Contracts;
using System.Collections.Generic;

namespace MyChessProject.Engine.Contracts
{
    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
