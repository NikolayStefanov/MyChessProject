using MyChessProject.Board.Contracts;
using MyChessProject.Common;
using MyChessProject.Figures.Contracts;
using System;

namespace MyChessProject.Board
{
    public class TheBoard : IBoard
    {
        private IFigure[,] board;

        public TheBoard(int rows = GlobalConstants.StandartGameTotalBoardRows, int cols=GlobalConstants.StandartGameTotalBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.board = new IFigure[rows,cols];
        }

        public int TotalRows { get; private set; }
        public int TotalCols { get; set; }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.nullFigureErrorMessage);
            Position.CheckIsValid(position);
            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = figure;

        }
        public void RemoveFigure(Position position)
        {
            Position.CheckIsValid(position);

            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = null;
        }

        public IFigure GetFigureAtPosition(Position position)
        {
            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            return this.board[arrRow, arrCol];
        }
        public void MoveFigureAtPosition(IFigure figure, Position from, Position to)
        {
            int arrFromRow = this.GetArrayRow(from.Row);
            int arrFromCol = this.GetArrayCol(from.Col);
            this.board[arrFromRow, arrFromCol] = null;

            int arrToRow = this.GetArrayRow(to.Row);
            int arrToCol = this.GetArrayCol(to.Col);
            this.board[arrToRow, arrToCol] = figure;
        }

        private int GetArrayRow(int chessRow)
        {
            return this.TotalRows - chessRow;
        }
        private int GetArrayCol(char chessCol)
        {
            return chessCol - 'a';
        }

    }
}
