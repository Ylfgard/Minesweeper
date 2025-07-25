using System;
using UnityEngine;

namespace Minesweeper.View
{
    public interface IInputPresenter : IDisposable
    {
        void HandleFlag(Vector2Int coordinates);
        void RestartGame();
        void HandleReveal(Vector2Int coordinates);
    }
}
