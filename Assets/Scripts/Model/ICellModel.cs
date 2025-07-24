using Minesweeper.Common;
using UnityEngine;

namespace Minesweeper.Model
{
    public interface ICellModel : IModel<ICellModel>
    {
        Vector2 Coordinates { get; }
        bool IsMine { get; set; }
        bool IsRevealed { get; set; }
        bool IsFlagged { get; set; }
    }
}
