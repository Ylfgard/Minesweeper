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

        public int MinesCount => _minefieldProvider.LeftMinesCount;
        public IMinefieldViewModel MinefieldModel => _minefieldViewModel ??= CreateViewModel();

        public event Action<int> MinesCountChanged;

        public GameScreenPresenter(IMinefieldProvider minefieldProvider)
        {
            _minefieldProvider = minefieldProvider;
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
