using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Minesweeper.View.Ui
{
    internal class InputDetector : MonoBehaviour
    {
        [Inject] private readonly IInputPresenter _presenter;
        [Inject] private readonly IGameFlowPresenter _gameFlowPresenter;

        [SerializeField] private GraphicRaycaster graphicRaycaster;

        private bool _inputIsLocked;

        private void Awake()
        {
            _gameFlowPresenter.GameStarted += OnGameStarted;
            _gameFlowPresenter.GameWin += LockInput;
            _gameFlowPresenter.GameLose += LockInput;
        }

        private void OnDestroy()
        {
            _presenter.Dispose();
            _gameFlowPresenter.GameStarted -= OnGameStarted;
            _gameFlowPresenter.GameWin -= LockInput;
            _gameFlowPresenter.GameLose -= LockInput;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                _presenter.RestartGame();

            if (_inputIsLocked)
                return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
                if (IsClickedOnCell(out var cellView))
                    _presenter.HandleReveal(cellView.Coordinates);

            if (Input.GetKeyDown(KeyCode.Mouse1))
                if (IsClickedOnCell(out var cellView))
                    _presenter.HandleFlag(cellView.Coordinates);
        }

        private bool IsClickedOnCell(out CellView cell)
        {
            var results = new List<RaycastResult>();
            graphicRaycaster.Raycast(new PointerEventData(EventSystem.current) { position = Input.mousePosition }, results);

            if (results.Count > 0)
            {
                RaycastResult raycastResult = results[0];
                if (raycastResult.gameObject.TryGetComponent(out cell))
                    return true;
            }

            cell = null;
            return false;
        }

        private void OnGameStarted()
        {
            _inputIsLocked = false;
        }

        private void LockInput()
        {
            _inputIsLocked = true;
        }
    }
}
