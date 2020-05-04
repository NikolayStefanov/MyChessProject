using MyChessProject.Common;
using MyChessProject.Engine.Contracts;
using MyChessProject.Engine.Initializations;
using MyChessProject.Board;
using MyChessProject.InputProviders.Contracts;
using MyChessProject.Players.Contracts;
using MyChessProject.Renderers.Contracts;
using System.Collections.Generic;
using MyChessProject.Board.Contracts;
using MyChessProject.Players;
using System;
using System.Linq;
using MyChessProject.Figures.Contracts;
using MyChessProject.Movements.Contracts;
using MyChessProject.Movements.Strategies;

namespace MyChessProject.Engine
{
    public class TwoPlayerEngine : IChessEngine
    {
        private  IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;
        private readonly IMovementStrategy movementStrategy;


        private int currentPlayerIndex;

        public TwoPlayerEngine(IRenderer render, IInputProvider inputProvider)
        {
            this.renderer = render;
            this.input = inputProvider;
            this.movementStrategy = new NormalMovementStrategy();
            this.board = new TheBoard();
        }

       

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            //TODO remove using MyChessProject.Players;
            this.players = new List<IPlayer>
            {
                new Player("Pesho", ChessColor.Black),
                new Player("Gosho", ChessColor.White)
            };//input.GetPlayers(GlobalConstants.StandartGameNumberOfPlayers);

            this.SetFirstPlayerIndex();
            gameInitializationStrategy.Initialize(this.players, this.board);
            this.renderer.RenderBoard(this.board);
        }

        public void Start()
        {
            while (true)
            {
                IFigure figure = null;
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                    var from = move.From;
                    var to = move.To;
                    figure = this.board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsEmpty(figure, to);

                    var availableMovements = figure.Move(this.movementStrategy);
                    this.ValidateMovements(figure, availableMovements, move);

                    this.board.MoveFigureAtPosition(figure, from, to);
                    this.renderer.RenderBoard(this.board);

                    // TODO: On every move check if we are in check
                    // TODO: Check pawn on last row
                    // TODO: If not castle - move figure (check castle - check if castle is valid, check pawn for An-pasan)
                    // TODO: If in check - check checkmate
                    // TODO: If not in check - check draw
                    // TODO: Continue
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(string.Format(ex.Message, figure.GetType().Name));
                }
            }
        }
        private void ValidateMovements(IFigure figure, IEnumerable<IMovement> availableMovements, Move move)
        {
            var validMoveFound = false;
            var foundException = new Exception();
            foreach (var movement in availableMovements)
            {
                try
                {
                    movement.ValidateMove(figure, this.board, move);
                    validMoveFound = true;
                    break;
                }
                catch (Exception ex)
                {
                    foundException = ex;
                }
            }

            if (!validMoveFound)
            {
                throw foundException;
            }
        }

        private void CheckIfToPositionIsEmpty(IFigure figure, Position to)
        {
            var figureAtPosition = this.board.GetFigureAtPosition(to);
            if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
            {
                throw new InvalidOperationException($"You already have a figure at {to.Col}{to.Row}!");
            }
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position from)
        {
            if (figure == null)
            {
                throw new InvalidOperationException($"Position {from.Col}{from.Row} is empty!");
            }
            else if (figure.Color != player.Color)
            {
                throw new InvalidOperationException($"The figure at {from.Col}{from.Row} is not yours!");
            }
        }

        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }
        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i-1;
                    return;
                }
            }
        }
        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;

            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }
            return this.players[this.currentPlayerIndex];
        }
    }
}
