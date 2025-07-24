using UnityEngine;

namespace Minesweeper.View
{
    public interface ICellViewModel : IViewModel<ICellViewModel>
    {
        Vector2 Coordinates { get; }
        bool IsMine { get; }
        bool IsRevealed { get; }
        bool IsFlagged { get; }
    }
}
