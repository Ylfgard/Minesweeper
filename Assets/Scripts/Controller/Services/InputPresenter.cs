using Minesweeper.Model;
using Minesweeper.View;
using UnityEngine;

namespace Minesweeper.Controller.Services
{
    internal class InputPresenter : IInputPresenter
    {
        private readonly IMinefieldProvider _minefieldProvider;
        private readonly MinefieldUseCase _minefieldUseCase;

        public InputPresenter(IMinefieldProvider minefieldProvider, 
            MinefieldUseCase minefieldUseCase)
        {
            _minefieldProvider = minefieldProvider;
            _minefieldUseCase = minefieldUseCase;
        }

        public void HandleReveal(Vector2Int coordinates)
        {
            _minefieldProvider.GetCell(coordinates.x, coordinates.y).IsFlagged = true;
        }

        public void HandleFlag(Vector2Int coordinates)
        {
            _minefieldProvider.GetCell(coordinates.x, coordinates.y).IsRevealed = true;
        }

        public void HandleRestartPressed()
        {
            _minefieldUseCase.GenerateNewMinefield();
        }
    }
}
