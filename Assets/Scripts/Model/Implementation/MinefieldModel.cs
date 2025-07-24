namespace Minesweeper.Model.Implementation
{
    internal class MinefieldModel : IMinefieldModel
    {
        private CellModel[,] _cells;

        public ICellModel[,] Cells => _cells;

        public MinefieldModel(int horizontalSize, int verticalSize)
        {
            _cells = new CellModel[horizontalSize, verticalSize];
        }
    }
}
