using UnityEngine;

namespace Minesweeper.Model.Implementation
{
    internal class MinefieldModel : BaseModel<IMinefieldModel>, IMinefieldModel
    {
        private CellModel[,] _cells;

        protected override IMinefieldModel Model => this;

        public CellModel[,] Cells
        {
            get => _cells;
            set
            {
                _cells = value;
                Notify();
            }
        }
 
        public int HorizontalSize => Cells.GetLength(1);
        public int VerticalSize => Cells.GetLength(0);
        ICellModel[,] IMinefieldModel.Cells => _cells;
    }
}
