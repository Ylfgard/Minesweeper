using UnityEngine;

namespace Minesweeper.View
{
    public interface ICellViewModel : IViewModel<ICellViewModel>
    {
        Vector2Int Coordinates { get; }
        bool IsMine { get; }
        bool IsRevealed { get; }
        bool IsFlagged { get; }
        int AdjacentMinesCount { get; }
    }
}
