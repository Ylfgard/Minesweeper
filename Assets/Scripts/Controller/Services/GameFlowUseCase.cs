using Minesweeper.Common;
using Minesweeper.Model;
using System.Threading.Tasks;

namespace Minesweeper.Controller.Services
{
    internal class GameFlowUseCase
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly IMinefieldProvider _minefieldProvider;
        private readonly MinefieldGenerator _minefieldGenerator;
        private readonly GameFlowPresenter _gameFlowPresenter;

        public GameFlowUseCase(ILoadingScreen loadingScreen,
            IMinefieldProvider minefieldProvider,
            MinefieldGenerator minefieldGenerator,
            GameFlowPresenter gameFlowPresenter)
        {
            _loadingScreen = loadingScreen;
            _minefieldProvider = minefieldProvider;
            _minefieldGenerator = minefieldGenerator;
            _gameFlowPresenter = gameFlowPresenter;
        }

        public async Task RestartGame()
        {
            _loadingScreen.Show();

            await _minefieldGenerator.GenerateNewMinefield();
            _gameFlowPresenter.NotifyGameRestart();

            _loadingScreen.Hide();

        }

        public Task GameLose()
        {
            var mines = _minefieldProvider.GetMines();
            foreach (var mine in mines)
                mine.IsRevealed = true;
            _gameFlowPresenter.NotifyGameLose();

            return Task.CompletedTask;
        }

        public Task WinGame()
        {
            var mines = _minefieldProvider.GetMines();
            foreach (var mine in mines)
                mine.IsFlagged = true;
            _gameFlowPresenter.NotifyGameWin();

            return Task.CompletedTask;
        }
    }
}
