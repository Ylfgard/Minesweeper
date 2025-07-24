using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Minesweeper.Model.Implementation
{
    internal class MinefieldProvider : IMinefieldProvider
    {
        private MinefieldModel _model;

        public int LeftMinesCount => GetMines().Count - GetFlags().Count;

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

        public IReadOnlyList<ICellModel> GetMines()
        {
            return _model.Cells.Cast<ICellModel>().Where(c => c.IsMine).ToList();
        }

        public IReadOnlyList<ICellModel> GetFlags()
        {
            return _model.Cells.Cast<ICellModel>().Where(c => c.IsFlagged).ToList();
        }

        public IReadOnlyList<ICellModel> GetRevealed()
        {
            return _model.Cells.Cast<ICellModel>().Where(c => c.IsRevealed).ToList();
        }

        public IReadOnlyList<ICellModel> GetHidden()
        {
            return _model.Cells.Cast<ICellModel>().Where(c => c.IsRevealed == false && 
                c.IsFlagged == false).ToList();
        }
    }
}
