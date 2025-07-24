namespace Minesweeper.Model
{
    public interface IMinefieldModel
    {
        ICellModel [,] Cells { get; } 
    }
}
