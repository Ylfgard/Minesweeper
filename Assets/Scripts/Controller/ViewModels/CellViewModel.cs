using Minesweeper.Model;
using Minesweeper.View;
using UnityEngine;

namespace Minesweeper.Controller.ViewModels
{
    internal class CellViewModel : BaseViewModel<ICellViewModel, ICellModel>, ICellViewModel
    {
        private bool _isMine;
        private bool _isRevealed;
        private bool _isFlagged;
        private int _adjacentMinesCount;

        protected override ICellViewModel ViewModel => this;

        public Vector2Int Coordinates { get; }

        public bool IsMine
        {
            get => _isMine;
            set
            {
                _isMine = value;
                Notify();
            }
        }

        public bool IsRevealed
        {
            get => _isRevealed;
            set
            {
                _isRevealed = value;
                Notify();
            }
        }

        public bool IsFlagged
        {
            get => _isFlagged;
            set
            {
                _isFlagged = value;
                Notify();
            }
        }

        public int AdjacentMinesCount
        {
            get => _adjacentMinesCount;
            set
            {
                _adjacentMinesCount = value;
                Notify();
            }
        }

        public CellViewModel(ICellModel model)
        {
            Coordinates = model.Coordinates;
            model.Attach(this);
            UpdateObserver(model);
        }

        public override void UpdateObserver(ICellModel model)
        {
            _isMine = model.IsMine;
            _isRevealed = model.IsRevealed;
            _isFlagged = model.IsFlagged;
            _adjacentMinesCount = model.AdjacentMinesCount;
            Notify();
        }
    }
}
