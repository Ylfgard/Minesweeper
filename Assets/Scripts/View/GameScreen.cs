using Minesweeper.View.View;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Minesweeper.View.Assets.Scripts.View
{
    internal class GameScreen : MonoBehaviour
    {
        [Inject] private IGamePresenter _gamePresenter;

        [SerializeField] private TextMeshProUGUI _minesCount;
        [SerializeField] private TextMeshProUGUI _timer;
        [SerializeField] private MinefieldView _minefieldView;

        public void Initialize()
        {
            var minefieldModel = _gamePresenter.MinefieldModel;
            minefieldModel.Attach(_minefieldView);

            _gamePresenter.MinesCountChanged += UpdateMinesCount;
        }

        private void OnDestroy()
        {
            var minefieldModel = _gamePresenter.MinefieldModel;
            minefieldModel.Detach(_minefieldView);

            _gamePresenter.MinesCountChanged -= UpdateMinesCount;
        }

        private void UpdateMinesCount(int count)
        {
            _minesCount.text = count.ToString();
        }
    }

    public interface IGamePresenter
    {
        public event Action<int> MinesCountChanged;

        IMinefieldViewModel MinesCount { get; }
        IMinefieldViewModel MinefieldModel { get; }
    }
}
