using Minesweeper.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Minesweeper.Controller.Services
{
    internal class MinefieldUseCase
    {
        private readonly IMinefieldProvider _minefieldProvider;
        private readonly GameScreenPresenter _gameScreenPresenter;
        private readonly GameFlowUseCase _gameFlowUseCase;

        public MinefieldUseCase(IMinefieldProvider minefieldProvider,
            GameScreenPresenter gameScreenPresenter,
            GameFlowUseCase gameFlowUseCase)
        {
            _minefieldProvider = minefieldProvider;
            _gameScreenPresenter = gameScreenPresenter;
            _gameFlowUseCase = gameFlowUseCase;
        }

        public async Task HandleReveal(Vector2Int coordinates)
        {
            var cell = _minefieldProvider.GetCell(coordinates.x, coordinates.y);
            if (cell.IsRevealed)
                return;

            if (cell.IsMine)
            {
                cell.IsRevealed = true;
                await _gameFlowUseCase.LoseGame();
                return;
            }

            var model = _minefieldProvider.GetModel();
            RevealCellAndAdjacent(cell, model);
            if (_minefieldProvider.LeftMinesCount == _minefieldProvider.GetHidden().Count &&
                _minefieldProvider.GetFlags().All(c => c.IsMine))
                await _gameFlowUseCase.WinGame();
        }

        public Task HandleFlag(Vector2Int coordinates)
        {
            var cell = _minefieldProvider.GetCell(coordinates.x, coordinates.y);
            if (cell.IsRevealed)
                return Task.CompletedTask;
            cell.IsFlagged = !cell.IsFlagged;

            _gameScreenPresenter.NotifyMinesCountChange();
            return Task.CompletedTask;
        }

        private void RevealCellAndAdjacent(ICellModel cell, IMinefieldModel model)
        {
            var coordinates = cell.Coordinates;
            cell.IsRevealed = true;
            if (cell.AdjacentMinesCount > 0)
                return;

            int yMin = Mathf.Clamp(coordinates.y - 1, 0, model.VerticalSize - 1);
            int yMax = Mathf.Clamp(coordinates.y + 1, 0, model.VerticalSize - 1);
            int xMin = Mathf.Clamp(coordinates.x - 1, 0, model.HorizontalSize - 1);
            int xMax = Mathf.Clamp(coordinates.x + 1, 0, model.HorizontalSize - 1);

            for (var y = yMin; y <= yMax; y++)
                for (var x = xMin; x <= xMax; x++)
                    if (model.Cells[y, x].IsRevealed == false)
                        RevealCellAndAdjacent(model.Cells[y, x], model);
        }
    }

    internal class GameFlowUseCase
    {
        public Task LoseGame()
        {
            throw new NotImplementedException();
        }

        public Task WinGame()
        {
            throw new NotImplementedException();
        }
    }
}
