using Minesweeper.View;
using UnityEngine;

namespace Minesweeper.Controller.Services
{
    internal class InputPresenter : IInputPresenter
    {
        private readonly MinefieldUseCase _minefieldUseCase;
        private readonly RestartUseCase _restartUseCase;

        public InputPresenter(MinefieldUseCase minefieldUseCase,
            RestartUseCase restartUseCase)
        {
            _minefieldUseCase = minefieldUseCase;
            _restartUseCase = restartUseCase;
        }

        public async void HandleReveal(Vector2Int coordinates)
        {
            await _minefieldUseCase.HandleReveal(coordinates);
        }

        public async void HandleFlag(Vector2Int coordinates)
        {
            await _minefieldUseCase.HandleFlag(coordinates);
        }

        public async void HandleRestartPressed()
        {
            await _restartUseCase.RestartGame();
        }
    }
}
