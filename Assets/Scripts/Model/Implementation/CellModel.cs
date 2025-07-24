using UnityEngine;

namespace Minesweeper.Model.Implementation
{
    internal class CellModel : BaseModel<ICellModel>, ICellModel
    {
        public bool IsMine;
        public bool IsRevealed;
        public bool IsFlagged;

        protected override ICellModel Model => this;

        public Vector2Int Coordinates { get; }

        bool ICellModel.IsMine
        {
            get => IsMine;
            set
            {
                IsMine = value;
                Notify();
            }
        }
        
        bool ICellModel.IsRevealed
        {
            get => IsRevealed;
            set
            {
                IsRevealed = value;
                Notify();
            }
        }
        
        bool ICellModel.IsFlagged
        {
            get => IsFlagged;
            set
            {
                IsFlagged = value;
                Notify();
            }
        }

        public CellModel(Vector2Int coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
