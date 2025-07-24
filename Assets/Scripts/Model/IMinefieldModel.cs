using System;

namespace Minesweeper.Model
{
    public interface IMinefieldModel : IModel<IMinefieldModel> 
    {
        int HorizontalSize { get; }
        int VerticalSize { get; }
        ICellModel [,] Cells { get; } 
    }
}
