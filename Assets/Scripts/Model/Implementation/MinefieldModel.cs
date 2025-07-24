namespace Minesweeper.Model.Implementation
{
    internal class MinefieldModel : IMinefieldModel
    {
        private CellModel[,] _cells;

        public ICellModel[,] Cells => _cells;

        public MinefieldModel(int horizontalSize, int verticalSize)
        {
            _cells = new CellModel[horizontalSize, verticalSize];
            for (int y = 0;  y < verticalSize; y++)
                for (int x = 0; x < horizontalSize; x++)
                    _cells[x, y] = new CellModel();
        }
    }
}
