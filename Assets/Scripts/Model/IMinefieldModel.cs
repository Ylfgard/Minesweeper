using System;

namespace Minesweeper.Model
{
    public interface IMinefieldModel : IModel<IMinefieldModel> 
    {
        ICellModel [,] Cells { get; } 
    }
}
