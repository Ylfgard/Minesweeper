namespace Minesweeper.Model
{
    public interface ICellModel
    {
        bool IsMine { get; set; }
        bool IsRevealed { get; set; }
        bool IsFlagged { get; set; }
    }
}
