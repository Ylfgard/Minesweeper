using Minesweeper.View;
using System;

namespace Minesweeper.Controller.Services
{
    internal class GameFlowPresenter : IGameFlowPresenter
    {
        public event Action GameStarted;
        public event Action FirstCellClicked;
        public event Action GameLose;
        public event Action GameWin;

        public void NotifyGameRestart()
        {
            GameStarted?.Invoke();
        }

        public void NotifyFirstCellClick()
        {
            FirstCellClicked?.Invoke();
        }

        public void NotifyGameLose()
        {
            GameLose?.Invoke();
        }

        public void NotifyGameWin()
        {
            GameWin?.Invoke();
        }
    }
}
