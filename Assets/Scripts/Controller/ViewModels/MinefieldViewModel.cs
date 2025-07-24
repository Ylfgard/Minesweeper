using Minesweeper.Model;
using Minesweeper.View;
using System.Collections.Generic;

namespace Minesweeper.Controller.ViewModels
{
    internal class MinefieldViewModel : BaseViewModel<IMinefieldViewModel, IMinefieldModel>,
        IMinefieldViewModel
    {
        private readonly List<IViewObserver<ICellViewModel>> _observers = new();

        private CellViewModel[,] _cells;

        protected override IMinefieldViewModel ViewModel => this;

        public CellViewModel[,] Cells
        {
            get => _cells;
            set
            {
                _cells = value;
                Notify();
            }
        }

        ICellViewModel[,] IMinefieldViewModel.Cells => Cells;

        public MinefieldViewModel(IMinefieldModel model)
        {
            model.Attach(this);
            UpdateObserver(model);
        }

        public override void UpdateObserver(IMinefieldModel model)
        {
            var vertical = model.Cells.GetLength(0);
            var horizontal = model.Cells.GetLength(1);
            _cells = new CellViewModel[vertical, horizontal];
            for (int y = 0; y < vertical; y++)
            {
                for (int x = 0; x < horizontal; x++)
                {
                    _cells[y, x] = new CellViewModel(model.Cells[y, x]);
                }
            }

            Notify();
        }
    }
}
