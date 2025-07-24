using System;

namespace Minesweeper.Model
{
    public interface IMinefieldProvider
    {
        IMinefieldModel CreateNewMinefield(int horizontalSize, int verticalSize);
        IMinefieldModel GetModel();
        ICellModel GetCell(int x, int y);
    }
}
