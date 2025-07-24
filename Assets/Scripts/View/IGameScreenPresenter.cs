using System;
using UnityEngine;

namespace Minesweeper.View
{
    public interface IGameScreenPresenter
    {
        event Action<int> MinesCountChanged;

        int MinesCount { get; }
        IMinefieldViewModel MinefieldModel { get; }

        int GetAdjacentMinesCount(Vector2Int coordinates);
    }
}
