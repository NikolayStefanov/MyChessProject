using MyChessProject.Common;
using MyChessProject.Players.Contracts;
using System.Collections.Generic;

namespace MyChessProject.InputProviders.Contracts
{
    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);
        Move GetNextPlayerMove(IPlayer player);

    }
}
