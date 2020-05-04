using MyChessProject.Engine;
using MyChessProject.Engine.Contracts;
using MyChessProject.Engine.Initializations;
using MyChessProject.InputProviders;
using MyChessProject.InputProviders.Contracts;
using MyChessProject.Renderers;
using MyChessProject.Renderers.Contracts;
using System;

namespace MyChessProject
{
    public static class ChessFacade
    {
        public static void Start()
        {
            IRenderer renderer = new ConsoleRenderer();
            //renderer.RenderMainMenu();

            IInputProvider inputProvider = new ConsoleInputProvider();

            IChessEngine chessEngine = new TwoPlayerEngine(renderer, inputProvider);

            IGameInitializationStrategy gameInitializationStrategy = new StandartStartGameInitializationStrategy();

            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Start();

            Console.ReadLine();
        }
    }
}
