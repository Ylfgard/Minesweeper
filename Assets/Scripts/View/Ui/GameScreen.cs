using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace Minesweeper.View.Ui
{
    internal class GameScreen : MonoBehaviour, IGameScreen
    {
        [Inject] private readonly IGameScreenPresenter _presenter;

        [SerializeField] private TextMeshProUGUI _minesCount;
        [SerializeField] private TextMeshProUGUI _timer;
        [SerializeField] private MinefieldView _minefieldView;

        public Task Initialize()
        {
            var minefieldModel = _presenter.MinefieldModel;
            _minefieldView.SetViewModel(minefieldModel);

            _presenter.MinesCountChanged += UpdateMinesCount;
            return Task.CompletedTask;
        }

        private void OnDestroy()
        {
            var minefieldModel = _presenter.MinefieldModel;

            _presenter.MinesCountChanged -= UpdateMinesCount;
        }

        private void UpdateMinesCount(int count)
        {
            _minesCount.text = count.ToString();
        }
    }
}
