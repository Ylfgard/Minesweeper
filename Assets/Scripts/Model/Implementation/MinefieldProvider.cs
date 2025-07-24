using System;

namespace Minesweeper.Model.Implementation
{
    internal class MinefieldProvider : IMinefieldProvider
    {
        private MinefieldModel _model;

        public IMinefieldModel CreateNewMinefieldModel(int horizontalSize, int verticalSize)
        {
            _model = new MinefieldModel(horizontalSize, verticalSize);
            return _model;
        }

        public IMinefieldModel GetModel()
        {
            if (_model == null)
                throw new NullReferenceException("Minefield model is not created");
            return _model;
        }

        public ICellModel GetCell(int x, int y)
        {
            if (_model == null)
                throw new NullReferenceException("Minefield model is not created");
            return _model.Cells[y, x];
        }
    }
}
