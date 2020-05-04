using MyChessProject.Board.Contracts;

namespace MyChessProject.Renderers.Contracts
{
    public interface IRenderer
    {
        void RenderMainMenu();
        void RenderBoard(IBoard board);
        void PrintErrorMessage(string errorMessage);
    }
}
