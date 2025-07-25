using Minesweeper.Controller.ViewModels;
using Minesweeper.Model;
using Minesweeper.View;
using System;

namespace Minesweeper.Controller.Services
{
    internal class GameScreenPresenter : IGameScreenPresenter
    {
        private readonly IMinefieldProvider _minefieldProvider;

        private MinefieldViewModel _minefieldViewModel;
        private GameFlowUseCase _gameFlowUseCase;

        public event Action<int> MinesCountChanged;

        public int MinesCount => _minefieldProvider.LeftMinesCount;
        public IMinefieldViewModel MinefieldModel => _minefieldViewModel ??= CreateViewModel();

        public GameScreenPresenter(IMinefieldProvider minefieldProvider, 
            GameFlowUseCase gameFlowUseCase)
        {
            _minefieldProvider = minefieldProvider;
            _gameFlowUseCase = gameFlowUseCase;
        }

        public async void RestartGame()
        {
            await _gameFlowUseCase.RestartGame();
        }

        public void NotifyMinesCountChange()
        {
            MinesCountChanged?.Invoke(MinesCount);
        }

        private MinefieldViewModel CreateViewModel()
        {
            var model = _minefieldProvider.GetModel();
            var vm = new MinefieldViewModel(model);
            return vm;
        }
    }
}
