using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Minesweeper.View.Ui
{
    internal class InputDetector : MonoBehaviour
    {
        [Inject] private readonly IInputPresenter _inputPresenter;

        [SerializeField] private GraphicRaycaster graphicRaycaster;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                if (IsClickedOnCell(out var cellView))
                    _inputPresenter.HandleReveal(cellView.Coordinates);

            if (Input.GetKeyDown(KeyCode.Mouse1))
                if (IsClickedOnCell(out var cellView))
                    _inputPresenter.HandleFlag(cellView.Coordinates);

            if (Input.GetKeyDown(KeyCode.R))
                _inputPresenter.HandleRestartPressed();
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
    }
}
