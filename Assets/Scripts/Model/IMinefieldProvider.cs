using System.Collections.Generic;

namespace Minesweeper.Model
{
    public interface IMinefieldProvider
    {
        int LeftMinesCount { get; }
        
        IMinefieldModel CreateNewMinefield(int horizontalSize, int verticalSize);
        IMinefieldModel GetModel();
        ICellModel GetCell(int x, int y);
        IReadOnlyList<ICellModel> GetMines();
        IReadOnlyList<ICellModel> GetFlags();
        IReadOnlyList<ICellModel> GetRevealed();
        IReadOnlyList<ICellModel> GetHidden();
    }
}
