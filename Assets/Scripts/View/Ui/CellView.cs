using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Minesweeper.View.Ui
{
    internal class CellView : MonoBehaviour, IViewObserver<ICellViewModel>
    {
        [Inject] private readonly IGameScreenPresenter _gameScreenPresenter;

        [SerializeField] private Color normalColor = Color.white;
        [SerializeField] private Color revealedColor = Color.gray;
        [SerializeField] private Image background;
        [SerializeField] private GameObject mine;
        [SerializeField] private GameObject flag;
        [SerializeField] private TextMeshProUGUI minesCountText;

        public Vector2Int Coordinates => _viewModel?.Coordinates ?? Vector2Int.zero;

        private ICellViewModel _viewModel;

        public void SetViewModel(ICellViewModel vm)
        {
            _viewModel = vm;
            _viewModel.Attach(this);
            if (vm.IsMine == false)
            {
                var minesCount = _gameScreenPresenter.GetAdjacentMinesCount(_viewModel.Coordinates);
                minesCountText.text = minesCount == 0 ? string.Empty : minesCount.ToString();
            }
            UpdateObserver(vm);
        }

        private void OnDestroy()
        {
            _viewModel.Detach(this);
        }

        public void UpdateObserver(ICellViewModel vm)
        {
            background.color = vm.IsRevealed ? revealedColor : normalColor;
            minesCountText.gameObject.SetActive(vm.IsRevealed);
            mine.SetActive(vm.IsMine && vm.IsRevealed);
            flag.SetActive(vm.IsFlagged);
            if (vm.IsRevealed && vm.IsMine == false)
            {
                var minesCount = _gameScreenPresenter.GetAdjacentMinesCount(_viewModel.Coordinates);
                minesCountText.text = minesCount == 0 ? string.Empty : minesCount.ToString();
            }
        }
    }
}
