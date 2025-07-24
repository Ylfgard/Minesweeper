using UnityEngine;

namespace Minesweeper.Model.Implementation
{
    internal class MinefieldModel : BaseModel<IMinefieldModel>, IMinefieldModel
    {
        private CellModel[,] _cells;

        public ICellModel[,] Cells => _cells;

        protected override IMinefieldModel Model => this;

        public MinefieldModel(int horizontalSize, int verticalSize)
        {
            _cells = new CellModel[verticalSize, horizontalSize];
            for (int y = 0;  y < verticalSize; y++)
                for (int x = 0; x < horizontalSize; x++)
                    _cells[y, x] = new CellModel(new Vector2(x, y));
        }
    }
}
