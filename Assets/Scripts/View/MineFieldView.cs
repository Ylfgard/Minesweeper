using Minesweeper.Controller.Api;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Minesweeper.View.View
{
    [RequireComponent(typeof(GridLayoutGroup))]
    internal class MinefieldView : MonoBehaviour, IViewObserver<IMinefieldViewModel>   
    {
        [Inject] private readonly DiContainer _diContainer;
        [Inject] private readonly IMinefieldPresenter _minefieldPresenter;

        [SerializeField] private CellView cellPrefab;
        [SerializeField] private GridLayoutGroup layoutGroup;

        private CellView[,] _cells;
        
        private void OnValidate()
        {
            if (layoutGroup == null)
                layoutGroup = GetComponent<GridLayoutGroup>();
        }

        public void UpdateView(IMinefieldViewModel vm)
        {
            DetachCells(vm);
            _cells = new CellView[vm.Cells.GetLength(0), vm.Cells.GetLength(1)];

            layoutGroup.constraintCount = vm.Cells.GetLength(0);
            for (int y = 0; y < vm.Cells.GetLength(0); y++)
            {
                for (int x = 0; x < vm.Cells.GetLength(0); x++)
                {
                    var cell = _diContainer.InstantiatePrefabForComponent<CellView>(cellPrefab, transform);
                    vm.Cells[y, x].Attach(cell);
                }
            }
        }

        private void DetachCells(IMinefieldViewModel vm)
        {
            layoutGroup.constraintCount = vm.Cells.GetLength(0);
            for (int y = 0; y < vm.Cells.GetLength(0); y++)
            {
                for (int x = 0; x < vm.Cells.GetLength(0); x++)
                {
                    var cell = _cells[y, x];
                    vm.Cells[y, x].Detach(cell);
                }
            }
        }
    }

    public interface IMinefieldViewModel : IViewModel<IMinefieldViewModel>
    {
        ICellViewModel[,] Cells { get; }
    }
}
