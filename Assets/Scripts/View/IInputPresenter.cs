using UnityEngine;

namespace Minesweeper.View
{
    public interface IInputPresenter
    {
        void HandleFlag(Vector2Int coordinates);
        void HandleRestartPressed();
        void HandleReveal(Vector2Int coordinates);
    }
}
