using MyChessProject.Engine.Initializations;
using MyChessProject.Players.Contracts;
using System.Collections.Generic;

namespace MyChessProject.Engine.Contracts
{
    public interface IChessEngine
    {
        IEnumerable<IPlayer> Players { get; }
        void Initialize(IGameInitializationStrategy gameInitializationStrategy);

        void Start();

        void WinningConditions();
    }
}
