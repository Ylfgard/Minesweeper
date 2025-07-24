using System;

namespace Minesweeper.View
{
    public interface IGameScreenPresenter
    {
        event Action<int> MinesCountChanged;

        int MinesCount { get; }
        IMinefieldViewModel MinefieldModel { get; }
    }
}
