using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Minesweeper.View.Ui
{
    [RequireComponent(typeof(GridLayoutGroup))]
    internal class MinefieldView : MonoBehaviour, IViewObserver<IMinefieldViewModel>
    {
        [Inject] private readonly DiContainer _diContainer;

        private readonly List<CellView> _cells = new();

        [SerializeField] private CellView cellPrefab;
        [SerializeField] private GridLayoutGroup layoutGroup;

        private IMinefieldViewModel _viewModel;
        
        private void OnValidate()
        {
            if (layoutGroup == null)
                layoutGroup = GetComponent<GridLayoutGroup>();
        }

        public void SetViewModel(IMinefieldViewModel vm)
        {
            _viewModel = vm;
            _viewModel.Attach(this);
            UpdateObserver(_viewModel);
        }

        private void OnDestroy()
        {
            _viewModel.Detach(this);
        }

        public void UpdateObserver(IMinefieldViewModel vm)
        {
            foreach (var cell in _cells)
                Destroy(cell.gameObject);
            _cells.Clear();

            var vertical = vm.VerticalSize;
            var horizontal = vm.HorizontalSize;
            layoutGroup.constraintCount = vertical;
            for (int y = 0; y < vertical; y++)
            {
                for (int x = 0; x < horizontal; x++)
                {
                    var cell = _diContainer.InstantiatePrefabForComponent<CellView>(cellPrefab, transform);
                    cell.SetViewModel(vm.Cells[y, x]);
                    _cells.Add(cell);
                }
            }
        }
    }
}
