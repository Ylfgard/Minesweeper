using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Minesweeper.View.Ui
{
    internal class CellView : MonoBehaviour, IViewObserver<ICellViewModel>
    {
        [Inject] private readonly CellImageViewProvider _cellImageViewProvider;

        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI minesCountText;

        private ICellViewModel _viewModel;

        public void SetViewModel(ICellViewModel vm)
        {
            _viewModel = vm;
            _viewModel.Attach(this);
            UpdateObserver(vm);
        }

        private void OnDestroy()
        {
            _viewModel.Detach(this);
        }

        public void UpdateObserver(ICellViewModel vm)
        {

        }
    }
}
