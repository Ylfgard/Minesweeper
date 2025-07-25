using Minesweeper.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Minesweeper.Controller.Services
{
    internal class MinefieldUseCase
    {
        private readonly IMinefieldProvider _minefieldProvider;
        private readonly GameScreenPresenter _gameScreenPresenter;
        private readonly GameFlowUseCase _gameFlowUseCase;
        private readonly MinefieldGenerator _minefieldGenerator;

        public MinefieldUseCase(IMinefieldProvider minefieldProvider,
            GameScreenPresenter gameScreenPresenter,
            GameFlowUseCase gameFlowUseCase,
            MinefieldGenerator minefieldGenerator)
        {
            _minefieldProvider = minefieldProvider;
            _gameScreenPresenter = gameScreenPresenter;
            _gameFlowUseCase = gameFlowUseCase;
            _minefieldGenerator = minefieldGenerator;
        }

        public async Task HandleReveal(Vector2Int coordinates, bool isFirstClick)
        {
            var cell = _minefieldProvider.GetCell(coordinates.x, coordinates.y);
            if (cell.IsRevealed)
                return;

            if (cell.IsMine)
            {
                if (isFirstClick)
                {
                    RandomizeMine(cell);
                }
                else
                {
                    cell.IsRevealed = true;
                    await _gameFlowUseCase.GameLose();
                    return;
                }
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

        private void RandomizeMine(ICellModel cell)
        {
            cell.IsMine = false;
            var emptyCells = _minefieldProvider.GetHidden().Where(c => c.IsMine == false).ToArray();
            var randomCell = emptyCells[Random.Range(0, emptyCells.Length)];
            randomCell.IsMine = true;
            var model = _minefieldProvider.GetModel();
            RecalculateAdjacentMines(cell.Coordinates, model);
            RecalculateAdjacentMines(randomCell.Coordinates, model);

            var sb = new StringBuilder();
            for (int y = 0; y < model.VerticalSize; y++)
            {
                for (int x = 0; x < model.HorizontalSize; x++)
                {
                    sb.Append(model.Cells[y, x].IsMine ? '*' : model.Cells[y, x].AdjacentMinesCount.ToString());
                    sb.Append(' ');
                }
                sb.Append("\n");
            }
            Debug.Log($"Minefield after mine randomize \n{sb.ToString()}");
        }

        private void RecalculateAdjacentMines(Vector2Int coordinates, IMinefieldModel model)
        {
            void HandleCall(ICellModel cell)
            {
                cell.AdjacentMinesCount = _minefieldGenerator.GetAdjacentMinesCount(cell.Coordinates, model);
            }

            model.ForEachAdjacentCell(coordinates, HandleCall);
        }

        private void RevealCellAndAdjacent(ICellModel cell, IMinefieldModel model)
        {
            cell.IsRevealed = true;
            if (cell.AdjacentMinesCount > 0)
                return;

            void HandleCall(ICellModel cell)
            {
                if (cell.IsRevealed == false)
                    RevealCellAndAdjacent(cell, model);
            }

            model.ForEachAdjacentCell(cell.Coordinates, HandleCall);
        }
    }
}
