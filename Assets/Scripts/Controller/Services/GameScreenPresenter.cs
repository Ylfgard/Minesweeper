using Minesweeper.Controller.ViewModels;
using Minesweeper.Model;
using Minesweeper.View;
using System;
using UnityEngine;

namespace Minesweeper.Controller.Services
{
    internal class GameScreenPresenter : IGameScreenPresenter
    {
        private readonly IMinefieldProvider _minefieldProvider;
        private readonly IMinefieldUseCase _minefieldUseCase;

        private MinefieldViewModel _minefieldViewModel;

        public int MinesCount => 0;
        public IMinefieldViewModel MinefieldModel => _minefieldViewModel ??= CreateViewModel();

        public event Action<int> MinesCountChanged;

        public GameScreenPresenter(IMinefieldProvider minefieldProvider, 
            IMinefieldUseCase minefieldUseCase)
        {
            _minefieldProvider = minefieldProvider;
            _minefieldUseCase = minefieldUseCase;
        }

        private MinefieldViewModel CreateViewModel()
        {
            var model = _minefieldProvider.GetModel();
            var vm = new MinefieldViewModel(model);
            return vm;
        }

        public int GetAdjacentMinesCount(Vector2Int coordinates)
        {
            return _minefieldUseCase.GetAdjacentMinesCount(coordinates);
        }
    }
}
