using MyChessProject.Common;
using MyChessProject.Figures.Contracts;

namespace MyChessProject.Board.Contracts
{
    public interface IBoard
    {
        int TotalRows { get; }
        int TotalCols { get; }

        void AddFigure(IFigure figure, Position position);

        void RemoveFigure(Position position);
        void MoveFigureAtPosition(IFigure figure, Position from, Position to);
        IFigure GetFigureAtPosition(Position position);
    }
}
