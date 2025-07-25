using Minesweeper.View;
using System;
using UnityEngine;

namespace Minesweeper.Controller.Services
{
    internal class InputPresenter : IInputPresenter
    {
        private readonly MinefieldUseCase _minefieldUseCase;
        private readonly GameFlowUseCase _gameFlowUseCase;
        private readonly GameFlowPresenter _gameFlowPresenter;

        private bool _isFirstClick = true;

        public InputPresenter(MinefieldUseCase minefieldUseCase,
            GameFlowUseCase gameFlowUseCase,
            GameFlowPresenter gameFlowPresenter)
        {
            _minefieldUseCase = minefieldUseCase;
            _gameFlowUseCase = gameFlowUseCase;
            _gameFlowPresenter = gameFlowPresenter;

            _gameFlowPresenter.GameStarted += OnGameStarted;
        }

        public void Dispose()
        {
            _gameFlowPresenter.GameStarted -= OnGameStarted;
        }

        public async void HandleReveal(Vector2Int coordinates)
        {
            await _minefieldUseCase.HandleReveal(coordinates, _isFirstClick);
            if (_isFirstClick)
            {
                _gameFlowPresenter.NotifyFirstCellClick();
                _isFirstClick = false;
            }
        }

        public async void HandleFlag(Vector2Int coordinates)
        {
            await _minefieldUseCase.HandleFlag(coordinates);
        }

        public async void RestartGame()
        {
            await _gameFlowUseCase.RestartGame();
        }

        public void OnGameStarted()
        {
            _isFirstClick = true;
        }
    }
}
