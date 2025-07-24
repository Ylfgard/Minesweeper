using System;
using UnityEngine;

namespace Minesweeper.Model.Implementation
{
    internal class MinefieldProvider : IMinefieldProvider
    {
        private MinefieldModel _model;

        public IMinefieldModel CreateNewMinefield(int horizontalSize, int verticalSize)
        {
            _model ??= new MinefieldModel();

            var cells = new CellModel[verticalSize, horizontalSize];
            for (int y = 0; y < verticalSize; y++)
                for (int x = 0; x < horizontalSize; x++)
                    cells[y, x] = new CellModel(new Vector2Int(x, y));

            _model.Cells = cells;
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
