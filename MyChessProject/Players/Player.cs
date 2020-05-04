using MyChessProject.Common;
using MyChessProject.Figures.Contracts;
using MyChessProject.Players.Contracts;
using System;
using System.Collections.Generic;

namespace MyChessProject.Players
{
    public class Player: IPlayer
    {
        private readonly ICollection<IFigure> figures;
        public Player(string name, ChessColor color) 
        {
            this.Name = name;
            this.figures = new List<IFigure>();
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public string Name { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.nullFigureErrorMessage);
            //TODO check the color of the player
            this.CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }
        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.nullFigureErrorMessage);
            //TODO check the color of the player
            this.CheckIfFigureDoesNotExists(figure);
            this.figures.Remove(figure);

        }
        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException("Current player already owns this figure!");
            }
        }
        private void CheckIfFigureDoesNotExists(IFigure figure)
        {
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException("Current player doesn't own this figure!");
            }
        }
    }
}
