using System;

namespace MyChessProject.Common
{
    public struct Position
    {

        public static Position FromArrayCoordinates(int arrRow, int arrCol, int totalRows)
        {
            return new Position(totalRows - arrRow, (char)(arrCol + 'a'));
        }
        public static Position FromChessCoordinates(int chessRow, char chessCol)
        {
            var newPosition = new Position(chessRow, chessCol);
            CheckIsValid(newPosition);
            return newPosition;
        }

        public static void CheckIsValid(Position position)
        {
            if (position.Row < GlobalConstants.MinimumRowValue || position.Row > GlobalConstants.MaximumRowValue)
            {
                throw new IndexOutOfRangeException("Selected row position is invalid!");
            }
            if (position.Col < GlobalConstants.MinimumColValue || position.Row > GlobalConstants.MaximumColValue)
            {
                throw new IndexOutOfRangeException("Selected col position is invalid!");
            }
        }
        public Position(int row, char col) : this()
        {
            this.Row = row;
            this.Col = col;
        }
        public int Row { get; private set; }
        public char Col { get; private set; }
    }
}
