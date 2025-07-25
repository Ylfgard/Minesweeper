using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Minesweeper.View.Ui
{
    internal class GameScreen : MonoBehaviour, IGameScreen
    {
        [Inject] private readonly IGameScreenPresenter _presenter;
        [Inject] private readonly IGameFlowPresenter _gameFlowPresenter;

        [SerializeField] private TextMeshProUGUI _gameMessage;
        [SerializeField] private TextMeshProUGUI _minesCount;
        [SerializeField] private TextMeshProUGUI _timer;
        [SerializeField] private MinefieldView _minefieldView;
        [SerializeField] private Button restartButton;

        private float _passedTime;
        private bool _timerIsActive;

        public Task Initialize()
        {
            var minefieldModel = _presenter.MinefieldModel;
            _minefieldView.SetViewModel(minefieldModel);
            OnGameStarted();

            restartButton.onClick.AddListener(_presenter.RestartGame);
            _gameFlowPresenter.GameStarted += OnGameStarted;
            _gameFlowPresenter.FirstCellClicked += StartTimer;
            _gameFlowPresenter.GameLose += OnGameLose;
            _gameFlowPresenter.GameWin += OnGameWin;
            _presenter.MinesCountChanged += UpdateMinesCount;
            return Task.CompletedTask;
        }

        private void OnDestroy()
        {
            var minefieldModel = _presenter.MinefieldModel;

            restartButton.onClick.RemoveListener(_presenter.RestartGame);
            _gameFlowPresenter.GameStarted -= OnGameStarted;
            _gameFlowPresenter.FirstCellClicked -= StartTimer;
            _gameFlowPresenter.GameLose -= OnGameLose;
            _gameFlowPresenter.GameWin -= OnGameWin;
            _presenter.MinesCountChanged -= UpdateMinesCount;
        }

        private void Update()
        {
            if (_timerIsActive == false)
                return;

            _passedTime += Time.deltaTime;
            _timer.text = ((int)_passedTime).ToString();
        }

        private void OnGameStarted()
        {
            UpdateMinesCount(_presenter.MinesCount);
            _timer.text = "0";
            _passedTime = 0;
            _timerIsActive = false;
            _gameMessage.text = "Press R to restart";
        }

        private void StartTimer()
        {
            _timerIsActive = true;
        }

        private void OnGameWin()
        {
            _timerIsActive = false;
            _gameMessage.text = "Victory! Press R to restart";
        }

        private void OnGameLose()
        {
            _timerIsActive = false;
            _gameMessage.text = "Defeat! Press R to restart";
        }

        private void UpdateMinesCount(int count)
        {
            _minesCount.text = count.ToString();
        }
    }
}
