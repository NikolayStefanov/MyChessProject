using MyChessProject.Board.Contracts;
using MyChessProject.Common;
using MyChessProject.Common.Console;
using MyChessProject.Renderers.Contracts;
using System;
using System.Threading;

namespace MyChessProject.Renderers
{
    public class ConsoleRenderer : IRenderer
    {
        private const string chessLogo = "My Chess";
        private const ConsoleColor DarkSquareConsoleColor = ConsoleColor.Blue;
        private const ConsoleColor LightSquareConsoleColer = ConsoleColor.Cyan;
        private const ConsoleColor FrameColor = ConsoleColor.DarkCyan;


        public ConsoleRenderer()
        {
            //TODO change this magical numbers with something not magical :D 
            if (Console.WindowWidth < 100 || Console.WindowHeight < 80)
            {
                Console.ResetColor();
                Console.WriteLine("Please make the Console window and buffer size to 100x80! For best experience use Raster Fonts 8x9!");
                Environment.Exit(0);
            }
        }

        public void RenderBoard(IBoard board)
        {
            //TODO validate Console dimentions

            var startRowPrint = Console.WindowWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var startColPrint = Console.WindowHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharactersPerColPerBoardSquare;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            this.PrintBorder(startRowPrint, startColPrint, board.TotalRows, board.TotalCols);


            Console.BackgroundColor = ConsoleColor.White;
            int counter = 0;
            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentRowPrint = startRowPrint + left * ConsoleConstants.CharactersPerRowPerBoardSquare;
                    currentColPrint = startColPrint + top * ConsoleConstants.CharactersPerColPerBoardSquare;

                    ConsoleColor backgroundColor;
                    if (counter % 2 == 0)
                    {
                        backgroundColor = DarkSquareConsoleColor;
                        Console.BackgroundColor = DarkSquareConsoleColor;
                    }
                    else
                    {
                        backgroundColor = LightSquareConsoleColer;
                        Console.BackgroundColor = LightSquareConsoleColer;
                    }

                    var position = Position.FromArrayCoordinates(top, left, board.TotalRows);

                    var figure = board.GetFigureAtPosition(position);
                    ConsoleHelper.PrintFigure(figure, backgroundColor, currentRowPrint, currentColPrint);


                    counter++;
                }
                counter++;

            }
        }
        public void PrintErrorMessage(string errorMessage)
        {
            ConsoleHelper.ClearRow(ConsoleConstants.ConsoleRowForPlayer);
            Console.SetCursorPosition(Console.WindowWidth / 2 - errorMessage.Length/2, ConsoleConstants.ConsoleRowForPlayer);
            Console.Write(errorMessage);
            Thread.Sleep(2000);
            ConsoleHelper.ClearRow(ConsoleConstants.ConsoleRowForPlayer);
        }

        public void RenderMainMenu()
        {

            ConsoleHelper.SetCursorAtCenter(chessLogo.Length);
            Console.WriteLine(chessLogo);

            //TODO  add main menu
            Thread.Sleep(1000);
        }
        private void PrintBorder(int startRowPrint, int startColPrint, int boardTotalRows, int boardTotalCols)
        {
            var start = startRowPrint + 4;
            for (int i = 0; i < boardTotalCols; i++)
            {
                Console.SetCursorPosition(start + i * ConsoleConstants.CharactersPerRowPerBoardSquare, startColPrint - 1);
                Console.Write((char)('A' + i));
                Console.SetCursorPosition(start + i * ConsoleConstants.CharactersPerRowPerBoardSquare, startColPrint +boardTotalRows* ConsoleConstants.CharactersPerRowPerBoardSquare);
                Console.Write((char)('A' + i));
            }
            start = startColPrint + ConsoleConstants.CharactersPerColPerBoardSquare / 2;
            for (int i = 0; i < boardTotalRows; i++)
            {
                Console.SetCursorPosition(startRowPrint-1, start+ i * ConsoleConstants.CharactersPerColPerBoardSquare);
                Console.Write(boardTotalRows-i);
                Console.SetCursorPosition(startRowPrint + boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare, start + i * ConsoleConstants.CharactersPerColPerBoardSquare);
                Console.Write(boardTotalRows - i);
            }

            for (int i = startRowPrint - 2; i < startRowPrint + boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = FrameColor;
                Console.SetCursorPosition(i, startColPrint - 2);
                Console.Write(" ");
            }
            for (int i = startRowPrint - 2; i < startRowPrint + boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = FrameColor;
                Console.SetCursorPosition(i, startColPrint + boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare + 1);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = FrameColor;
                Console.SetCursorPosition(startRowPrint + boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare + 1, i);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare + 2; i++)
            {
                Console.BackgroundColor = FrameColor;
                Console.SetCursorPosition(startRowPrint - 2, i);
                Console.Write(" ");
            }
        }
    }
}
