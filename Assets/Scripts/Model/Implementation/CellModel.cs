namespace Minesweeper.Model.Implementation
{
    public class CellModel : ICellModel
    {
        public bool IsMine;
        public bool IsRevealed;
        public bool IsFlagged;

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
    }
}
