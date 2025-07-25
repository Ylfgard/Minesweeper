using System;

namespace Minesweeper.View
{
    public interface IGameFlowPresenter
    {
        event Action GameStarted;
        event Action FirstCellClicked;
        event Action GameLose;
        event Action GameWin;
    }
}
