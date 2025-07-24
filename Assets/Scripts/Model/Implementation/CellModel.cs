using UnityEngine;

namespace Minesweeper.Model.Implementation
{
    internal class CellModel : BaseModel<ICellModel>, ICellModel
    {
        public bool IsMine;
        public bool IsRevealed;
        public bool IsFlagged;

        public Vector2 Coordinates { get; }

        protected override ICellModel Model => this;

        bool ICellModel.IsMine
        {
            get => IsMine;
            set => IsMine = value;
        }
        
        bool ICellModel.IsRevealed
        {
            get => IsRevealed;
            set => IsRevealed = value;
        }
        
        bool ICellModel.IsFlagged
        {
            get => IsFlagged;
            set => IsFlagged = value;
        }

        public CellModel(Vector2 coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
